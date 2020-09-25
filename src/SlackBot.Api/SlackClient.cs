using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models;
using SlackBot.Api.Models.Bot.Info.Request;
using SlackBot.Api.Models.Bot.Info.Response;
using SlackBot.Api.Models.Chat.Delete.Request;
using SlackBot.Api.Models.Chat.Delete.Response;
using SlackBot.Api.Models.Chat.DeleteScheduledMessage.Request;
using SlackBot.Api.Models.Chat.GetPermalink.Request;
using SlackBot.Api.Models.Chat.GetPermalink.Response;
using SlackBot.Api.Models.Chat.PostEphemeral.Request;
using SlackBot.Api.Models.Chat.PostEphemeral.Response;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.Chat.ScheduledMessagesList.Request;
using SlackBot.Api.Models.Chat.ScheduledMessagesList.Response;
using SlackBot.Api.Models.Chat.ScheduleMessage.Request;
using SlackBot.Api.Models.Chat.ScheduleMessage.Response;
using SlackBot.Api.Models.Chat.Update.Request;
using SlackBot.Api.Models.Chat.Update.Response;
using SlackBot.Api.Models.Conversation;
using SlackBot.Api.Models.Conversation.Archive.Request;
using SlackBot.Api.Models.Conversation.Close.Request;
using SlackBot.Api.Models.Conversation.Close.Response;
using SlackBot.Api.Models.Conversation.Create.Request;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.Conversation.Info.Request;
using SlackBot.Api.Models.Conversation.Invite.Request;
using SlackBot.Api.Models.Conversation.Join.Request;
using SlackBot.Api.Models.Conversation.Join.Response;
using SlackBot.Api.Models.Conversation.Leave.Request;
using SlackBot.Api.Models.Conversation.Leave.Response;
using SlackBot.Api.Models.Conversation.List.Request;
using SlackBot.Api.Models.Conversation.Open.Request;
using SlackBot.Api.Models.Conversation.Open.Response;
using SlackBot.Api.Models.Conversation.Unarchive.Request;
using SlackBot.Api.Models.Emoji.List.Response;
using SlackBot.Api.Models.File.Delete.Request;
using SlackBot.Api.Models.File.Info.Request;
using SlackBot.Api.Models.File.Info.Response;
using SlackBot.Api.Models.File.List.Request;
using SlackBot.Api.Models.File.List.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.Pin.Add.Request;
using SlackBot.Api.Models.Pin.List.Request;
using SlackBot.Api.Models.Pin.List.Response;
using SlackBot.Api.Models.Pin.Remove.Request;
using SlackBot.Api.Models.Reaction.Add.Request;
using SlackBot.Api.Models.Reaction.Get.Request;
using SlackBot.Api.Models.Reaction.Get.Response;
using SlackBot.Api.Models.Reaction.List.Request;
using SlackBot.Api.Models.Reaction.List.Response;
using SlackBot.Api.Models.Reaction.Remove.Request;
using SlackBot.Api.Models.TeamProfile.Get.Request;
using SlackBot.Api.Models.TeamProfile.Get.Response;
using SlackBot.Api.Models.User;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.GetPresence.Request;
using SlackBot.Api.Models.User.GetPresence.Response;
using SlackBot.Api.Models.User.Info.Request;
using SlackBot.Api.Models.User.List.Request;
using SlackBot.Api.Models.User.List.Response;
using SlackBot.Api.Models.User.LookupByEmail.Request;
using SlackBot.Api.Models.User.SetPresence.Request;

namespace SlackBot.Api
{
    public class SlackClient : SlackClientBase
	{
		public SlackClient(HttpClient httpClient)
            : base(httpClient)
		{
		}

		#region Bot
		
		/// <summary>
		/// Gets information about a bot user.
		/// </summary>
		public Task<BotInfoResponse> GetBotInfoAsync(BotInfoRequest botInfoRequest)
			=> SendGetAsync<BotInfoRequest, BotInfoResponse>("bots.info", botInfoRequest);
		
		#endregion

		#region Emoji
		
		/// <summary>
		/// Lists custom emoji for a team.
		/// </summary>
		public Task<EmojiListResponse> EmojiListAsync()
			=> SendGetAsync<EmojiListResponse>("emoji.list");

		#endregion
		
		#region File
		
		/// <summary>
		/// Deletes a file.
		/// </summary>
		public Task<SlackBaseResponse> DeleteFileAsync(FileToDelete fileToDelete)
			=> SendPostFormUrlEncodedAsync("files.delete", fileToDelete);
		
		/// <summary>
		/// Gets information about a file.
		/// </summary>
		public Task<FileInfoResponse> GetFileInfoAsync(FileInfoRequest fileInfoRequest)
			=> SendGetAsync<FileInfoRequest, FileInfoResponse>("files.info", fileInfoRequest);
		
		/// <summary>
		/// List for a team, in a channel, or from a user with applied filters.
		/// </summary>
		public Task<FileListResponse> GetFileListAsync(FileListRequest fileListRequest)
			=> SendGetAsync<FileListRequest, FileListResponse>("files.list", fileListRequest);

		/// <summary>
		/// Creates content as a file and uploads it.
		/// </summary>
		public Task<UploadFileResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> SendPostMultipartFormAsync<ContentToUpload, UploadFileResponse>("files.upload", contentToUpload);

		/// <summary>
		/// Uploads a file.
		/// </summary>
		public Task<UploadFileResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> SendPostMultipartFormAsync<FileToUpload, UploadFileResponse>("files.upload", fileToUpload);
		
		#endregion
		
		#region Chat

		/// <summary>
		/// Deletes a message.
		/// </summary>
		public Task<DeletedMessageResponse> DeleteMessageAsync(MessageToDelete messageToDelete)
			=> SendPostFormUrlEncodedAsync<MessageToDelete, DeletedMessageResponse>("chat.delete", messageToDelete);

		/// <summary>
		/// Deletes a pending scheduled message from the queue.
		/// </summary>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(ScheduledMessageToDelete scheduledMessageToDelete)
			=> SendPostJsonStringAsync("chat.deleteScheduledMessage", scheduledMessageToDelete);

		/// <summary>
		/// Retrieve a permalink URL for a specific extant message.
		/// </summary>
		public Task<MessagePermalinkResponse> GetMessagePermalinkAsync(MessagePermalinkRequest messagePermalinkRequest)
			=> SendGetAsync<MessagePermalinkRequest, MessagePermalinkResponse>("chat.getPermalink", messagePermalinkRequest);

		/// <summary>
		/// Sends an ephemeral message to a user in a channel.
		/// </summary>
		public Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync(EphemeralMessage ephemeralMessage)
			=> SendPostJsonStringAsync<EphemeralMessage, SendEphemeralMessageResponse>("chat.postEphemeral", ephemeralMessage);

		/// <summary>
		/// Sends a message to a channel.
		/// </summary>
		public Task<SendMessageResponse> SendMessageAsync(Message message)
			=> SendPostJsonStringAsync<Message, SendMessageResponse>("chat.postMessage", message);
		
		/// <summary>
		/// Schedules a message to be sent to a channel.
		/// </summary>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(MessageToSchedule messageToSchedule)
			=> SendPostJsonStringAsync<MessageToSchedule, ScheduleMessageResponse>("chat.scheduleMessage", messageToSchedule);
		
		/// <summary>
		/// Returns a list of scheduled messages.
		/// </summary>
		public Task<ScheduledMessageListResponse> GetScheduledMessagesAsync(ScheduledMessageListRequest scheduledMessageListRequest)
			=> SendPostFormUrlEncodedAsync<ScheduledMessageListRequest, ScheduledMessageListResponse>("chat.scheduledMessages.list", scheduledMessageListRequest);
		
		/// <summary>
		/// Updates a message.
		/// </summary>
		public Task<UpdateMessageResponse> UpdateMessageAsync(MessageToUpdate messageToUpdate)
			=> SendPostJsonStringAsync<MessageToUpdate, UpdateMessageResponse>("chat.update", messageToUpdate);
		
		#endregion
        
		#region Conversation
		
		/// <summary>
		/// Archives a conversation.
		/// </summary>
        public Task<SlackBaseResponse> ArchiveConversationAsync(ConversationToArchive conversationToArchive) 
            => SendPostFormUrlEncodedAsync("conversations.archive", conversationToArchive);
		
		/// <summary>
		/// Closes a direct message or multi-person direct message.
		/// </summary>
        public Task<ClosedConversationResponse> CloseConversationAsync(ConversationToClose conversationToClose) 
            => SendPostFormUrlEncodedAsync<ConversationToClose, ClosedConversationResponse>("conversations.close", conversationToClose);
		
		/// <summary>
		/// Initiates a public or private channel-based conversation.
		/// </summary>
        public Task<ConversationResponse> CreateChannelAsync(ChannelToCreate channelToCreate) 
            => SendPostFormUrlEncodedAsync<ChannelToCreate, ConversationResponse>("conversations.create", channelToCreate);
		
		/// <summary>
		/// Fetches a conversation's history of messages and events.
		/// </summary>
        public Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("conversations.history", conversationsHistory);
		
		/// <summary>
		/// Retrieve information about a conversation.
		/// </summary>
        public Task<ConversationResponse> ConversationInfoAsync(ConversationToGetInfo conversationToGetInfo) 
            => SendGetAsync<ConversationToGetInfo, ConversationResponse>("conversations.info", conversationToGetInfo);
		
		/// <summary>
		/// Invites users to a channel.
		/// </summary>
        public Task<ConversationResponse> InviteToConversationAsync(ConversationToInvite conversationToInvite) 
            => SendPostFormUrlEncodedAsync<ConversationToInvite, ConversationResponse>("conversations.invite", conversationToInvite);
		
		/// <summary>
		/// Joins an existing conversation.
		/// </summary>
        public Task<JoinToConversationResponse> JoinToConversationAsync(ConversationToJoin conversationToJoin) 
            => SendPostFormUrlEncodedAsync<ConversationToJoin, JoinToConversationResponse>("conversations.join", conversationToJoin);
		
		/// <summary>
		/// Leaves a conversation.
		/// </summary>
        public Task<LeaveConversationResponse> LeaveConversationAsync(ConversationToLeave conversationToLeave) 
            => SendPostFormUrlEncodedAsync<ConversationToLeave, LeaveConversationResponse>("conversations.leave", conversationToLeave);
		
		/// <summary>
		/// Lists all channels in a Slack team.
		/// </summary>
        public Task<ConversationListResponse> ConversationListAsync(ConversationListRequest conversationListRequest) 
            => SendGetAsync<ConversationListRequest, ConversationListResponse>("conversations.list", conversationListRequest);
		
		/// <summary>
		/// Opens or resumes a direct message or multi-person direct message.
		/// </summary>
        public Task<OpenedConversationResponse> OpenConversationsAsync(ConversationToOpen conversationToOpen) 
            => SendPostFormUrlEncodedAsync<ConversationToOpen, OpenedConversationResponse>("conversations.open", conversationToOpen);
		
		/// <summary>
		/// Reverses conversation archival.
		/// </summary>
        public Task<SlackBaseResponse> UnarchiveConversationAsync(ConversationToUnarchive conversationToUnarchive) 
            => SendPostFormUrlEncodedAsync("conversations.unarchive", conversationToUnarchive);
		
		#endregion

		#region Pin

		/// <summary>
		/// Pins an item to a channel.
		/// </summary>
		public Task<SlackBaseResponse> PinMessageAsync(PinItem pinItem)
			=> SendPostFormUrlEncodedAsync("pins.add", pinItem);

		/// <summary>
		/// Lists items pinned to a channel.
		/// </summary>
		public Task<PinListResponse> GetPinListAsync(PinListRequest pinListRequest)
			=> SendGetAsync<PinListRequest, PinListResponse>("pins.list", pinListRequest);

		/// <summary>
		/// Un-pins an item from a channel.
		/// </summary>
		public Task<SlackBaseResponse> RemovePinAsync(PinItemToRemove pinItemToRemove)
			=> SendPostFormUrlEncodedAsync("pins.remove", pinItemToRemove);

		#endregion

		#region Reaction

		/// <summary>
		/// Adds a reaction to an item.
		/// </summary>
		public Task<SlackBaseResponse> AddReactionAsync(Reaction reaction)
			=> SendPostFormUrlEncodedAsync("reactions.add", reaction);

		/// <summary>
		/// Gets reactions for an item.
		/// </summary>
		public Task<ReactionsByItemResponse> GetReactionsByItemAsync(ReactionsByItemRequest reactionsByItemRequest)
			=> SendGetAsync<ReactionsByItemRequest, ReactionsByItemResponse>("reactions.get", reactionsByItemRequest);

		/// <summary>
		/// Lists reactions made by a user.
		/// </summary>
		public Task<ReactionsByUserResponse> GetReactionsByUserAsync(ReactionsByUserRequest reactionsByUserRequest)
			=> SendGetAsync<ReactionsByUserRequest, ReactionsByUserResponse>("reactions.list", reactionsByUserRequest);

		/// <summary>
		/// Removes a reaction from an item.
		/// </summary>
		public Task<SlackBaseResponse> RemoveReactionAsync(ReactionToRemove reactionToRemove)
			=> SendPostFormUrlEncodedAsync("reactions.remove", reactionToRemove);

		#endregion

		#region TeamProfile

		/// <summary>
		/// Retrieve a team's profile.
		/// </summary>
		public Task<TeamProfileResponse> TeamProfileAsync(TeamProfileRequest teamProfileRequest)
			=> SendGetAsync<TeamProfileRequest, TeamProfileResponse>("team.profile.get", teamProfileRequest);

		#endregion

		#region User

		/// <summary>
		/// Gets conversations list the calling user may access.
		/// </summary>
		public Task<ConversationListResponse> UserConversationsAsync(UserConversations userConversations)
			=> SendGetAsync<UserConversations, ConversationListResponse>("users.conversations", userConversations);

		/// <summary>
		/// Gets user presence information.
		/// </summary>
		public Task<UserPresenceResponse> UserPresenceAsync(UserPresenceRequest userPresenceRequest)
			=> SendGetAsync<UserPresenceRequest, UserPresenceResponse>("users.getPresence", userPresenceRequest);

		/// <summary>
		/// Gets information about a user.
		/// </summary>
		public Task<UserResponse> UserInfoAsync(UserToGetInfo userToGetInfo)
			=> SendGetAsync<UserToGetInfo, UserResponse>("users.info", userToGetInfo);

		/// <summary>
		/// Lists all users in a Slack team.
		/// </summary>
		public Task<UserListResponse> UserListAsync(UserListRequest userListRequest)
			=> SendGetAsync<UserListRequest, UserListResponse>("users.list", userListRequest);

		/// <summary>
		/// Find a user with an email address.
		/// </summary>
		public Task<UserResponse> UserByEmailAsync(UserByEmailRequest userByEmailRequest)
			=> SendGetAsync<UserByEmailRequest, UserResponse>("users.lookupByEmail", userByEmailRequest);

		/// <summary>
		/// Manually sets user presence.
		/// </summary>
		public Task<SlackBaseResponse> SetUserPresenceAsync(SetUserPresenceRequest setUserPresenceRequest)
			=> SendPostFormUrlEncodedAsync("users.setPresence", setUserPresenceRequest);
		
		#endregion
	}
}