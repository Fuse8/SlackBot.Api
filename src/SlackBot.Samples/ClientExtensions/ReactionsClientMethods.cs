using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class ReactionsClientMethods
	{
		public static async Task<SlackBaseResponse> AddReactionAsync(SlackClient slackClient, string channelName)
		{
			var (addReactionResponse, _) = await AddReactionInternalAsync(slackClient, channelName);

			return addReactionResponse;
		}
		
		public static async Task<ReactionsByItemResponse> GetReactionsByItemAsync(SlackClient slackClient, string channelName)
		{
			var (_, sendMessageResponse) = await AddReactionInternalAsync(slackClient, channelName);
			await AddReactionToMessageAsync(slackClient, sendMessageResponse, "smile");

			return await slackClient.Reactions.GetAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
		}
		
		public static async Task<ReactionsByUserResponse> GetReactionsByUserAsync(SlackClient slackClient, string channelName)
		{
			var (_, sendMessageResponse) = await AddReactionInternalAsync(slackClient, channelName);
			await AddReactionToMessageAsync(slackClient, sendMessageResponse, "smile");

			return await slackClient.Reactions.ListAsync();
		}
		
		public static async Task<SlackBaseResponse> RemoveReactionAsync(SlackClient slackClient, string channelName)
		{
			const string EmojiName = "grin";
			var (_, sendMessageResponse) = await AddReactionInternalAsync(slackClient, channelName, EmojiName);
			
			return await slackClient.Reactions.RemoveAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, EmojiName);
		}

		private static async Task<(SlackBaseResponse AddReactionResponse, SendMessageResponse SendMessageResponse)> AddReactionInternalAsync(
			SlackClient slackClient,
			string channelName,
			string emojiName = "+1")
		{
			var sendMessageResponse = await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelName, nameof(AddReactionAsync));

			var addReactionResponse = await AddReactionToMessageAsync(slackClient, sendMessageResponse, emojiName);

			return (addReactionResponse, sendMessageResponse);
		}

		private static Task<SlackBaseResponse> AddReactionToMessageAsync(SlackClient slackClient, SendMessageResponse sendMessageResponse, string emojiName)
			=> slackClient.Reactions.AddAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, emojiName);
	}
}