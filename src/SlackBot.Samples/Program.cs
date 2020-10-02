using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Samples.ClientExtensions;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;

#region disable formatting rules
	
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedVariable
// ReSharper disable UnusedMethodReturnValue.Local
#pragma warning disable 1998

#endregion

namespace SlackBot.Samples
{
	public class Program
	{
		private static readonly string _channelName;
		private static readonly string _token;
		private static readonly string _userId;
		
		static Program()
		{
			var configuration = GetConfiguration();
			var slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");
			_channelName = slackBotSettings.ChannelName;
			_token = slackBotSettings.Token;
			_userId = slackBotSettings.UserId;
		}

		// ReSharper disable once InconsistentNaming
		public static async Task Main()
		{
			#region Emoji

			using (var emojiClient = SlackClientFactory.CreateClient<EmojiClient>(_token))
			{
				/* Gets custom emoji list for team */
				var getEmojiListResponse = await EmojiClientMethods.GetEmojiListAsync(emojiClient); /**/
			}

			#endregion
			
			#region Team

			using (var disposedSlackClient = SlackClientFactory.CreateSlackClient(_token))
			{
				var teamClient = disposedSlackClient.Team;
				
				/* Gets team info */
				var getTeamInfoResponse = await TeamClientMethods.GetTeamInfoAsync(teamClient);/**/
			}

			#endregion
			
			#region Bots

			using (var disposedSlackClient = SlackClientFactory.CreateSlackClient(_token))
			{
				/* Gets bot info */
				var getBotInfoResponse = await BotsClientMethods.GetBotInfoAsync(disposedSlackClient, _channelName); /**/
			}

			#endregion
			
			var slackClient = SlackClientFactory.CreateSlackClient(_token);

			#region Files

			/* Uploads plain file content */
			var uploadContentResponse = await FilesClientMethods.UploadContentAsync(slackClient, _channelName); /**/

			/* Uploads file from disk */
			var uploadFileResponse = await FilesClientMethods.UploadFileAsync(slackClient, _channelName); /**/

			/* Deletes file */
			var deleteFileResponse = await FilesClientMethods.DeleteFileAsync(slackClient, _channelName); /**/

			/* Gets file info */
			var getFileInfoResponse = await FilesClientMethods.GetFileInfoAsync(slackClient, _channelName); /**/

			/* Gets file list */
			var getFileListResponse = await FilesClientMethods.GetFileListAsync(slackClient, _channelName); /**/

			#endregion

			#region FilesRemote

			/* Adds remote file */
			var addRemoteFileResponse = await FilesRemoteClientMethods.AddRemoteFileAsync(slackClient); /**/

			/* Gets remote file info */
			var getRemoteFileInfoResponse = await FilesRemoteClientMethods.GetRemoteFileInfoAsync(slackClient); /**/

			/* Gets remote file list */
			var getRemoteFileListResponse = await FilesRemoteClientMethods.GetRemoteFileListAsync(slackClient); /**/

			/* Removes remote file */
			var removeRemoteFileResponse = await FilesRemoteClientMethods.RemoveRemoteFileAsync(slackClient); /**/

			/* Shares remote file */
			var shareRemoteFileResponse = await FilesRemoteClientMethods.ShareRemoteFileAsync(slackClient, _channelName); /**/

			/* Updates remote file */
			var updateRemoteFileResponse = await FilesRemoteClientMethods.UpdateRemoteFileAsync(slackClient); /**/

			#endregion

			#region Chat

			/* Sends message with some blocks */
			var sendMessageWithBlocksResponse = await ChatClientMethods.SendMessageWithBlocksAsync(slackClient, _channelName); /**/

			/* Uploads some files and sends message with them */
			var sendMessageWithMultipleFilesResponse = await ChatClientMethods.SendMessageWithMultipleFilesAsync(slackClient, _channelName); /**/

			/* Sends ephemeral message */
			var sendEphemeralMessageResponse = await ChatClientMethods.SendEphemeralMessageAsync(slackClient, _channelName, _userId); /**/

			/* Deletes message */
			var deletedMessageResponse = await ChatClientMethods.DeleteMessageAsync(slackClient, _channelName); /**/

			/* Schedules message to channel */
			var scheduleMessageResponse = await ChatClientMethods.ScheduleMessageAsync(slackClient, _channelName); /**/

			/* Gets list of scheduled messages */
			var getScheduledMessageListResponse = await ChatClientMethods.GetScheduledMessageListAsync(slackClient, _channelName); /**/

			/* Deletes scheduled message */
			var deleteScheduledMessageResponse = await ChatClientMethods.DeleteScheduledMessageAsync(slackClient, _channelName); /**/

			/* Gets message permalink */
			var getMessagePermalinkResponse = await ChatClientMethods.GetMessagePermalinkAsync(slackClient, _channelName); /**/

			/* Updates message */
			var updateMessageResponse = await ChatClientMethods.UpdateMessageAsync(slackClient, _channelName); /**/

			#endregion

			#region Conversations

			/* Archives conversation */
			var archiveConversationResponse = await ConversationsClientMethods.ArchiveConversationAsync(slackClient, _channelName);/**/

			/* Closes conversation */
			var closeConversationResponse = await ConversationsClientMethods.CloseConversationAsync(slackClient, _userId);/**/

			/* Creates channel */
			var createChannelResponse = await ConversationsClientMethods.CreateChannelAsync(slackClient, _userId);/**/

			/* Gets conversation's history of messages and events */
			var getConversationsHistoryResponse = await ConversationsClientMethods.GetConversationsHistoryAsync(slackClient, _channelName);/**/

			/* Gets information about conversation */
			var getConversationInfoResponse = await ConversationsClientMethods.GetConversationInfoAsync(slackClient, _channelName);/**/

			/* Creates channel and invites user */
			var inviteToConversationResponse = await ConversationsClientMethods.InviteToConversationAsync(slackClient, _userId);/**/

			/* Joins to conversation */
			var joinToConversationResponse = await ConversationsClientMethods.JoinToConversationAsync(slackClient);/**/

			/* Kicks from conversation */
			var kickFromConversationResponse = await ConversationsClientMethods.KickFromConversationAsync(slackClient, _userId);/**/

			/* Leaves conversation */
			var leaveConversationResponse = await ConversationsClientMethods.LeaveConversationAsync(slackClient, _channelName);/**/

			/* Gets conversation list */
			var getConversationListResponse = await ConversationsClientMethods.GetConversationListAsync(slackClient);/**/

			/* Gets conversation's members */
			var getConversationMembersResponse = await ConversationsClientMethods.GetConversationMembersAsync(slackClient, _channelName);/**/

			/* Opens conversation */
			var openConversationResponse = await ConversationsClientMethods.OpenConversationAsync(slackClient, _userId);/**/

			/* Renames conversation */
			var renameConversationResponse = await ConversationsClientMethods.RenameConversationAsync(slackClient);/**/

			/* Gets message replies from conversation */
			var getConversationRepliesResponse = await ConversationsClientMethods.GetConversationRepliesAsync(slackClient, _channelName);/**/

			/* Sets conversation purpose */
			var setConversationPurposeResponse = await ConversationsClientMethods.SetConversationPurposeAsync(slackClient, _channelName);/**/

			/* Sets conversation purpose */
			var setConversationTopicResponse = await ConversationsClientMethods.SetConversationTopicAsync(slackClient, _channelName);/**/

			/* Unarchives conversation */
			var unarchiveConversationResponse = await ConversationsClientMethods.UnarchiveConversationAsync(slackClient, _channelName);/**/

			#endregion

			#region Pins

			/* Pins message */
			var pinMessageResponse = await PinsClientMethods.PinMessageAsync(slackClient, _channelName); /**/

			/* Get pinned items */
			var getPinListResponse = await PinsClientMethods.GetPinListAsync(slackClient, _channelName); /**/

			/* Removes pinned item */
			var removePinResponse = await PinsClientMethods.RemovePinAsync(slackClient, _channelName); /**/

			#endregion

			#region Reactions

			/* Adds reaction */
			var addReactionResponse = await ReactionsClientMethods.AddReactionAsync(slackClient, _channelName); /**/

			/* Gets reactions by item*/
			var getReactionsByItemResponse = await ReactionsClientMethods.GetReactionsByItemAsync(slackClient, _channelName); /**/

			/* Gets reactions by user*/
			var getReactionsByUserResponse = await ReactionsClientMethods.GetReactionsByUserAsync(slackClient, _channelName); /**/

			/* Removes reaction */
			var removeReactionResponse = await ReactionsClientMethods.RemoveReactionAsync(slackClient, _channelName);/**/

			#endregion

			#region TeamProfile

			/* Gets team profile */
			var getTeamProfileResponse = await TeamProfileClientMethods.GetTeamProfileAsync(slackClient);/**/

			#endregion

			#region UserGroups

			/* Creates user group */
			var createUserGroupResponse = await UserGroupsClientMethods.CreateUserGroupAsync(slackClient, _channelName);/**/

			/* Disables user group */
			var disableUserGroupResponse = await UserGroupsClientMethods.DisableUserGroupAsync(slackClient, _channelName);/**/

			/* Enables user group */
			var enableUserGroupResponse = await UserGroupsClientMethods.EnableUserGroupAsync(slackClient, _channelName);/**/

			/* Gets user group list */
			var getUserGroupListResponse = await UserGroupsClientMethods.GetUserGroupListAsync(slackClient, _channelName);/**/

			/* Updates user group */
			var updateUserGroupResponse = await UserGroupsClientMethods.UpdateUserGroupAsync(slackClient, _channelName);/**/

			#endregion

			#region UserGroupsUsers

			/* Gets user group users */
			var getUserGroupUserListResponse = await UserGroupsUsersClientMethods.GetUserGroupUserListAsync(slackClient, _channelName, _userId);/**/

			/* Updates users in user group */
			var updateUsersInUserGroupResponse = await UserGroupsUsersClientMethods.UpdateUsersInUserGroupAsync(slackClient, _channelName, _userId);/**/

			#endregion

			#region Users

			/* Gets list of user channels */
			var getUserConversationsResponse = await UsersClientMethods.GetUserConversationsAsync(slackClient);/**/

			/* Gets user presence information */
			var getUserPresenceResponse = await UsersClientMethods.GetUserPresenceAsync(slackClient, _userId);/**/

			/* Gets information about user */
			var getUserInfoResponse = await UsersClientMethods.GetUserInfoAsync(slackClient, _userId);/**/

			/* Gets list of all users */
			var getUserListResponse = await UsersClientMethods.GetUserListAsync(slackClient);/**/

			/* Gets user by email */
			var getUserByEmailResponse = await UsersClientMethods.GetUserByEmailAsync(slackClient, _userId);/**/

			/* Sets user presence */
			var setUserPresenceResponse = await UsersClientMethods.SetUserPresenceAsync(slackClient);/**/

			#endregion

			#region UsersProfile

			/* Gets user profile */
			var getUserProfileResponse = await UsersProfileClientMethods.GetUserProfileAsync(slackClient, _userId);/**/

			#endregion
		}

		private static IConfiguration GetConfiguration()
			=> new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", true)
				.Build();
	}
}