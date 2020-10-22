using System.Linq;
using System.Threading.Tasks;
using SlackBot.Api;
using SlackBot.Api.Exceptions;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class ConversationsClientMethods
	{
		private const string NewChannelName = "some-new-channel";
		
		public static async Task<SlackBaseResponse> ArchiveConversationAsync(SlackClient slackClient, string channelName, string conversationId = null)
		{
			var channelId = conversationId ?? await GetChannelIdAsync(slackClient, channelName);

			var archiveConversationResponse = await ArchiveConversationInternalAsync(slackClient, channelId);

			await UnarchiveConversationInternalAsync(slackClient, channelId);

			return archiveConversationResponse;
		}

		public static async Task<ClosedConversationResponse> CloseConversationAsync(SlackClient slackClient, string userId)
		{
			var openConversationResponse = await OpenConversationAsync(slackClient, userId);
			
			return await slackClient.Conversations.CloseAsync(openConversationResponse.Channel.Id);
		}

		public static Task<ConversationResponse> CreateChannelAsync(SlackClient slackClient, string userId)
			=> CreateChannelInternalAsync(slackClient);

		public static async Task<ConversationsHistoryResponse> GetConversationsHistoryAsync(SlackClient slackClient, string channelName)
        {
	        var channelId = await GetChannelIdAsync(slackClient, channelName);

			await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelId, nameof(GetConversationsHistoryAsync));

	        return await slackClient.Conversations.HistoryAsync(channelId, 1000);
        }

		public static async Task<ConversationResponse> GetConversationInfoAsync(SlackClient slackClient, string channelName)
        {
	        var channelId = await GetChannelIdAsync(slackClient, channelName);

	        return await slackClient.Conversations.InfoAsync(channelId, true, true);
        }

		public static async Task<ConversationResponse> InviteToConversationAsync(SlackClient slackClient, string userId)
        {
			var (channelId, _) = await TryCreateChannelAsync(slackClient);

			return await InviteToConversationInternalAsync(slackClient, channelId, userId);
        }

		public static async Task<ConversationResponse> JoinToConversationAsync(SlackClient slackClient)
        {
			var (channelId, _) = await TryCreateChannelAsync(slackClient);

			return await slackClient.Conversations.JoinAsync(channelId);
        }

		public static async Task<SlackBaseResponse> KickFromConversationAsync(SlackClient slackClient, string userId)
        {
			var (channelId, _) = await TryCreateChannelAsync(slackClient);
			
			await TryInviteToConversationAsync(slackClient, channelId, userId);

			return await slackClient.Conversations.KickAsync(channelId, userId); // TODO returns error "restricted_action" 
        }

		public static async Task<LeaveConversationResponse> LeaveConversationAsync(SlackClient slackClient, string channelName)
        {
			var channelId = await GetChannelIdAsync(slackClient, channelName);

			return await slackClient.Conversations.LeaveAsync(channelId);
        }

		public static Task<ConversationObjectListResponse> GetConversationListAsync(SlackClient slackClient)
			=> slackClient.Conversations.ListAsync("public_channel,private_channel,mpim,im", limit: 1000);

		public static async Task<ConversationMembersResponse> GetConversationMembersAsync(SlackClient slackClient, string channelName)
		{
			var channelId = await GetChannelIdAsync(slackClient, channelName);
			
			return await slackClient.Conversations.MembersAsync(channelId);
		}

		public static async Task<OpenedConversationResponse> OpenConversationAsync(SlackClient slackClient, string userId)
        {
			var openedConversationResponse = await slackClient.Conversations.OpenAsync(userId, true);

			await ChatClientMethods.SendSimpleMessageAsync(slackClient, openedConversationResponse.Channel.Id, nameof(OpenConversationAsync));

			return openedConversationResponse;
		}

		public static async Task<ConversationResponse> RenameConversationAsync(SlackClient slackClient)
		{
			var (channelId, channelName) = await TryCreateChannelAsync(slackClient);

			var renameConversationResponse = await slackClient.Conversations.RenameAsync(channelId, $"{channelName}-new-name");
			
			await slackClient.Conversations.RenameAsync(channelId, channelName);

			return renameConversationResponse;
		}

		public static async Task<ConversationRepliesResponse> GetConversationRepliesAsync(SlackClient slackClient, string channelName)
		{
			var channelId = await GetChannelIdAsync(slackClient, channelName);

			var parentMessage = await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelId, nameof(GetConversationRepliesAsync));

			var parentMessageTimestamp = parentMessage.Timestamp;
			await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelId, nameof(GetConversationRepliesAsync), parentMessageTimestamp);
			await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelId, nameof(GetConversationRepliesAsync), parentMessageTimestamp);

			return await slackClient.Conversations.RepliesAsync(channelId, parentMessageTimestamp);
		}

		public static async Task<ConversationResponse> SetConversationPurposeAsync(SlackClient slackClient, string channelName)
		{
			var channelId = await GetChannelIdAsync(slackClient, channelName);

			return await slackClient.Conversations.SetPurposeAsync(channelId, "new purpose");
		}

		public static async Task<ConversationResponse> SetConversationTopicAsync(SlackClient slackClient, string channelName)
		{
			var channelId = await GetChannelIdAsync(slackClient, channelName);

			return await slackClient.Conversations.SetTopicAsync(channelId, "new topic");
		}

		public static async Task<SlackBaseResponse> UnarchiveConversationAsync(SlackClient slackClient, string channelName)
        {
	        var channelId = await GetChannelIdAsync(slackClient, channelName);

			await ArchiveConversationInternalAsync(slackClient, channelId);

			return await UnarchiveConversationInternalAsync(slackClient, channelId);
        }

		public static async Task<string> GetChannelIdAsync(SlackClient slackClient, string channelName)
		{
			var conversationsHistoryResponse = await GetConversationListAsync(slackClient);
			
			var channelId = conversationsHistoryResponse?.Channels?.FirstOrDefault(p => p.Name == channelName)?.Id;

			return channelId;
		}

		private static async Task<(string ChannelId, string ChannelName)> TryCreateChannelAsync(SlackClient slackClient)
		{
			string channelId;
			string channelName = NewChannelName;

			try
			{
				var createChannelResponse = await CreateChannelInternalAsync(slackClient, channelName);
				channelId = createChannelResponse.Channel.Id;
			}
			catch (SlackApiResponseException e) when (e.Error == "name_taken")
			{
				channelId = await GetChannelIdAsync(slackClient, channelName);
			}

			return (channelId, channelName);
		}

		private static Task<ConversationResponse> CreateChannelInternalAsync(SlackClient slackClient, string channelName = NewChannelName)
			=> slackClient.Conversations.CreateAsync(channelName);

		private static async Task TryInviteToConversationAsync(SlackClient slackClient, string channelId, string userIds)
		{
			try
			{
				await InviteToConversationInternalAsync(slackClient, channelId, userIds);
			}
			catch (SlackApiResponseException e) when (e.Error == "already_in_channel")
			{
			}
		}

		private static Task<ConversationResponse> InviteToConversationInternalAsync(SlackClient slackClient, string channelId, string userIds)
			=> slackClient.Conversations.InviteAsync(channelId, userIds);

		private static Task<SlackBaseResponse> ArchiveConversationInternalAsync(SlackClient slackClient, string channelId)
			=> slackClient.Conversations.ArchiveAsync(channelId);

		private static Task<SlackBaseResponse> UnarchiveConversationInternalAsync(SlackClient slackClient, string channelId)
			=> slackClient.Conversations.UnarchiveAsync(channelId);
	}
}