using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Helpers;
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
using SlackBot.Api.Models.Conversation.Kick.Request;
using SlackBot.Api.Models.Conversation.Leave.Request;
using SlackBot.Api.Models.Conversation.Leave.Response;
using SlackBot.Api.Models.Conversation.List.Request;
using SlackBot.Api.Models.Conversation.Members.Request;
using SlackBot.Api.Models.Conversation.Members.Response;
using SlackBot.Api.Models.Conversation.Open.Request;
using SlackBot.Api.Models.Conversation.Open.Response;
using SlackBot.Api.Models.Conversation.Rename.Request;
using SlackBot.Api.Models.Conversation.Replies.Request;
using SlackBot.Api.Models.Conversation.Replies.Response;
using SlackBot.Api.Models.Conversation.SetPurpose.Request;
using SlackBot.Api.Models.Conversation.SetTopic.Request;
using SlackBot.Api.Models.Conversation.Unarchive.Request;
using SlackBot.Api.Models.Emoji.List.Response;
using SlackBot.Api.Models.File.Delete.Request;
using SlackBot.Api.Models.File.Info.Request;
using SlackBot.Api.Models.File.Info.Response;
using SlackBot.Api.Models.File.List.Request;
using SlackBot.Api.Models.File.List.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.FileRemote.Add.Request;
using SlackBot.Api.Models.FileRemote.Info.Request;
using SlackBot.Api.Models.FileRemote.List.Request;
using SlackBot.Api.Models.FileRemote.List.Response;
using SlackBot.Api.Models.FileRemote.Remove.Request;
using SlackBot.Api.Models.FileRemote.Share.Request;
using SlackBot.Api.Models.FileRemote.Update.Request;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.File;
using SlackBot.Api.Models.GeneralObjects.UserGroup;
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
using SlackBot.Api.Models.Team.Info.Request;
using SlackBot.Api.Models.Team.Info.Response;
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
using SlackBot.Api.Models.UserGroup.Create.Request;
using SlackBot.Api.Models.UserGroup.Disable.Request;
using SlackBot.Api.Models.UserGroup.Enable.Request;
using SlackBot.Api.Models.UserGroup.List.Request;
using SlackBot.Api.Models.UserGroup.List.Response;
using SlackBot.Api.Models.UserGroup.Update.Request;
using SlackBot.Api.Models.UserGroupUser.List.Request;
using SlackBot.Api.Models.UserGroupUser.List.Response;
using SlackBot.Api.Models.UserGroupUser.Update.Request;
using SlackBot.Api.Models.UserProfile.Get.Request;
using SlackBot.Api.Models.UserProfile.Get.Response;

namespace SlackBot.Api.Clients
{
    public class SlackClient : DisposableObjectBase
	{
		private readonly HttpClient _httpClient;
		
		private BotsClient _botsClient;
		private EmojiClient _emojiClient;
		private FilesClient _filesClient;
		private FilesRemoteClient _filesRemoteClient;
		private ChatClient _chatClient;
		private ConversationsClient _conversationsClient;
		private PinsClient _pinsClient;
		private ReactionsClient _reactionsClient;
		private TeamClient _teamClient;
		private TeamProfileClient _teamProfileClient;
		private UserGroupsClient _userGroupsClient;
		private UserGroupsUsersClient _userGroupsUsersClient;
		private UsersClient _usersClient;
		private UsersProfileClient _usersProfileClient;
		
		public SlackClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		#region Clients
		
		public BotsClient Bots => _botsClient ?? (_botsClient = new BotsClient(_httpClient));
		
		public EmojiClient Emoji => _emojiClient ?? (_emojiClient = new EmojiClient(_httpClient));
		
		public FilesClient Files => _filesClient ?? (_filesClient = new FilesClient(_httpClient));
		
		public FilesRemoteClient FilesRemote => _filesRemoteClient ?? (_filesRemoteClient = new FilesRemoteClient(_httpClient));
		
		public ChatClient Chat => _chatClient ?? (_chatClient = new ChatClient(_httpClient));
		
		public ConversationsClient Conversations => _conversationsClient ?? (_conversationsClient = new ConversationsClient(_httpClient));
		
		public PinsClient Pins => _pinsClient ?? (_pinsClient = new PinsClient(_httpClient));
		
		public ReactionsClient Reactions => _reactionsClient ?? (_reactionsClient = new ReactionsClient(_httpClient));
		
		public TeamClient Team => _teamClient ?? (_teamClient = new TeamClient(_httpClient));
		
		public TeamProfileClient TeamProfile => _teamProfileClient ?? (_teamProfileClient = new TeamProfileClient(_httpClient));
		
		public UserGroupsClient UserGroups => _userGroupsClient ?? (_userGroupsClient = new UserGroupsClient(_httpClient));
		
		public UserGroupsUsersClient UserGroupsUsers => _userGroupsUsersClient ?? (_userGroupsUsersClient = new UserGroupsUsersClient(_httpClient));

		public UsersClient Users => _usersClient ?? (_usersClient = new UsersClient(_httpClient));

		public UsersProfileClient UsersProfile => _usersProfileClient ?? (_usersProfileClient = new UsersProfileClient(_httpClient));
		
		#endregion

		#region Bot
		
		///<inheritdoc cref="BotsClient.InfoAsync"/>
		public Task<BotInfoResponse> GetBotInfoAsync(BotInfoRequest botInfoRequest)
			=> Bots.InfoAsync(botInfoRequest);
		
		#endregion

		#region Emoji
		
		///<inheritdoc cref="EmojiClient.ListAsync"/>
		public Task<EmojiListResponse> EmojiListAsync()
			=> Emoji.ListAsync();

		#endregion
		
		#region File
		
		///<inheritdoc cref="FilesClient.DeleteAsync"/>
		public Task<SlackBaseResponse> DeleteFileAsync(FileToDelete fileToDelete)
			=> Files.DeleteAsync(fileToDelete);
		
		///<inheritdoc cref="FilesClient.InfoAsync"/>
		public Task<FileInfoResponse> FileInfoAsync(FileInfoRequest fileInfoRequest)
			=> Files.InfoAsync(fileInfoRequest);

		///<inheritdoc cref="FilesClient.ListAsync"/>
		public Task<FileListResponse> FileListAsync(FileListRequest fileListRequest)
			=> Files.ListAsync(fileListRequest);

		///<inheritdoc cref="FilesClient.UploadContentAsync"/>
		public Task<SlackFileResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> Files.UploadContentAsync(contentToUpload);

		///<inheritdoc cref="FilesClient.UploadFileAsync"/>
		public Task<SlackFileResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> Files.UploadFileAsync(fileToUpload);
		
		#endregion

		#region FileRemote

		///<inheritdoc cref="FilesRemoteClient.AddAsync"/>
		public Task<SlackFileResponse> AddRemoteFileAsync(RemoteFile remoteFile)
			=> FilesRemote.AddAsync(remoteFile);

		///<inheritdoc cref="FilesRemoteClient.InfoAsync"/>
		public Task<SlackFileResponse> RemoteFileInfoAsync(RemoteFileInfoRequest remoteFileInfoRequest)
			=> FilesRemote.InfoAsync(remoteFileInfoRequest);

		///<inheritdoc cref="FilesRemoteClient.ListAsync"/>
		public Task<RemoteFileListResponse> RemoteFileListAsync(RemoteFileListRequest remoteFileListRequest)
			=> FilesRemote.ListAsync(remoteFileListRequest);

		///<inheritdoc cref="FilesRemoteClient.RemoveAsync"/>
		public Task<SlackBaseResponse> RemoveRemoteFileAsync(RemoteFileToRemove remoteFileToRemove)
			=> FilesRemote.RemoveAsync(remoteFileToRemove);

		///<inheritdoc cref="FilesRemoteClient.ShareAsync"/>
		public Task<SlackFileResponse> ShareRemoteFileAsync(RemoteFileToShare remoteFileToShare)
			=> FilesRemote.ShareAsync(remoteFileToShare);

		///<inheritdoc cref="FilesRemoteClient.UpdateAsync"/>
		public Task<SlackFileResponse> UpdateRemoteFileAsync(RemoteFileToUpdate remoteFileToUpdate)
			=> FilesRemote.UpdateAsync(remoteFileToUpdate);

		#endregion
		
		#region Chat

		///<inheritdoc cref="ChatClient.DeleteAsync"/>
		public Task<DeletedMessageResponse> DeleteMessageAsync(MessageToDelete messageToDelete)
			=> Chat.DeleteAsync(messageToDelete);

		///<inheritdoc cref="ChatClient.DeleteScheduledMessageAsync"/>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(ScheduledMessageToDelete scheduledMessageToDelete)
			=> Chat.DeleteScheduledMessageAsync(scheduledMessageToDelete);

		///<inheritdoc cref="ChatClient.GetPermalinkAsync"/>
		public Task<MessagePermalinkResponse> GetMessagePermalinkAsync(MessageToGetPermalink messageToGetPermalink)
			=> Chat.GetPermalinkAsync(messageToGetPermalink);

		///<inheritdoc cref="ChatClient.PostEphemeralAsync"/>
		public Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync(EphemeralMessage ephemeralMessage)
			=> Chat.PostEphemeralAsync(ephemeralMessage);

		///<inheritdoc cref="ChatClient.PostMessageAsync"/>
		public Task<SendMessageResponse> SendMessageAsync(Message message)
			=> Chat.PostMessageAsync(message);
		
		///<inheritdoc cref="ChatClient.ScheduleMessageAsync"/>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(MessageToSchedule messageToSchedule)
			=> Chat.ScheduleMessageAsync(messageToSchedule);
		
		///<inheritdoc cref="ChatClient.ScheduledMessagesListAsync"/>
		public Task<ScheduledMessageListResponse> GetScheduledMessagesAsync(ScheduledMessageListRequest scheduledMessageListRequest)
			=> Chat.ScheduledMessagesListAsync(scheduledMessageListRequest);
		
		///<inheritdoc cref="ChatClient.UpdateAsync"/>
		public Task<UpdateMessageResponse> UpdateMessageAsync(MessageToUpdate messageToUpdate)
			=> Chat.UpdateAsync(messageToUpdate);
		
		#endregion
        
		#region Conversation

		///<inheritdoc cref="ConversationsClient.ArchiveAsync"/>
		public Task<SlackBaseResponse> ArchiveConversationAsync(ConversationToArchive conversationToArchive)
			=> Conversations.ArchiveAsync(conversationToArchive);
		
		///<inheritdoc cref="ConversationsClient.CloseAsync"/>
        public Task<ClosedConversationResponse> CloseConversationAsync(ConversationToClose conversationToClose) 
            => Conversations.CloseAsync(conversationToClose);
		
		///<inheritdoc cref="ConversationsClient.CreateAsync"/>
        public Task<ConversationResponse> CreateChannelAsync(ChannelToCreate channelToCreate) 
            => Conversations.CreateAsync(channelToCreate);
		
		///<inheritdoc cref="ConversationsClient.HistoryAsync"/>
        public Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistory conversationsHistory) 
            => Conversations.HistoryAsync(conversationsHistory);
		
		///<inheritdoc cref="ConversationsClient.InfoAsync"/>
        public Task<ConversationResponse> ConversationInfoAsync(ConversationToGetInfo conversationToGetInfo) 
            => Conversations.InfoAsync(conversationToGetInfo);
		
		///<inheritdoc cref="ConversationsClient.InviteAsync"/>
        public Task<ConversationResponse> InviteToConversationAsync(ConversationToInvite conversationToInvite) 
            => Conversations.InviteAsync(conversationToInvite);
		
		///<inheritdoc cref="ConversationsClient.JoinAsync"/>
        public Task<JoinToConversationResponse> JoinToConversationAsync(ConversationToJoin conversationToJoin) 
            => Conversations.JoinAsync(conversationToJoin);
		
		///<inheritdoc cref="ConversationsClient.KickAsync"/>
        public Task<SlackBaseResponse> KickFromConversationAsync(KickFromConversationRequest kickFromConversationRequest) 
            => Conversations.KickAsync(kickFromConversationRequest);
		
		///<inheritdoc cref="ConversationsClient.LeaveAsync"/>
        public Task<LeaveConversationResponse> LeaveConversationAsync(ConversationToLeave conversationToLeave) 
            => Conversations.LeaveAsync(conversationToLeave);
		
		///<inheritdoc cref="ConversationsClient.ListAsync"/>
        public Task<ConversationListResponse> ConversationListAsync(ConversationListRequest conversationListRequest) 
            => Conversations.ListAsync(conversationListRequest);
		
		///<inheritdoc cref="ConversationsClient.MembersAsync"/>
        public Task<ConversationMembersResponse> ConversationMembersAsync(ConversationMembersRequest conversationMembersRequest) 
            => Conversations.MembersAsync(conversationMembersRequest);
		
		///<inheritdoc cref="ConversationsClient.OpenAsync"/>
        public Task<OpenedConversationResponse> OpenConversationAsync(ConversationToOpen conversationToOpen) 
            => Conversations.OpenAsync(conversationToOpen);
		
		///<inheritdoc cref="ConversationsClient.RenameAsync"/>
        public Task<ConversationResponse> RenameConversationAsync(ConversationToRename conversationToRename) 
            => Conversations.RenameAsync(conversationToRename);
		
		///<inheritdoc cref="ConversationsClient.RepliesAsync"/>
        public Task<ConversationRepliesResponse> ConversationRepliesAsync(ConversationRepliesRequest conversationRepliesRequest) 
            => Conversations.RepliesAsync(conversationRepliesRequest);
		
		///<inheritdoc cref="ConversationsClient.SetPurposeAsync"/>
        public Task<ConversationResponse> SetConversationPurposeAsync(ConversationPurposeRequest conversationPurposeRequest) 
            => Conversations.SetPurposeAsync(conversationPurposeRequest);
		
		///<inheritdoc cref="ConversationsClient.SetTopicAsync"/>
        public Task<ConversationResponse> SetConversationTopicAsync(ConversationTopicRequest conversationTopicRequest) 
            => Conversations.SetTopicAsync(conversationTopicRequest);
		
		///<inheritdoc cref="ConversationsClient.UnarchiveAsync"/>
        public Task<SlackBaseResponse> UnarchiveConversationAsync(ConversationToUnarchive conversationToUnarchive) 
            => Conversations.UnarchiveAsync(conversationToUnarchive);
		
		#endregion

		#region Pin

		///<inheritdoc cref="PinsClient.PinAsync"/>
		public Task<SlackBaseResponse> PinMessageAsync(PinItem pinItem)
			=> Pins.PinAsync(pinItem);

		///<inheritdoc cref="PinsClient.ListAsync"/>
		public Task<PinListResponse> PinListAsync(PinListRequest pinListRequest)
			=> Pins.ListAsync(pinListRequest);

		///<inheritdoc cref="PinsClient.RemoveAsync"/>
		public Task<SlackBaseResponse> RemovePinAsync(PinItemToRemove pinItemToRemove)
			=> Pins.RemoveAsync(pinItemToRemove);

		#endregion

		#region Reaction

		///<inheritdoc cref="ReactionsClient.AddAsync"/>
		public Task<SlackBaseResponse> AddReactionAsync(Reaction reaction)
			=> Reactions.AddAsync(reaction);

		///<inheritdoc cref="ReactionsClient.GetAsync"/>
		public Task<ReactionsByItemResponse> GetReactionsByItemAsync(ReactionsByItemRequest reactionsByItemRequest)
			=> Reactions.GetAsync(reactionsByItemRequest);

		///<inheritdoc cref="ReactionsClient.ListAsync"/>
		public Task<ReactionsByUserResponse> GetReactionsByUserAsync(ReactionsByUserRequest reactionsByUserRequest)
			=> Reactions.ListAsync(reactionsByUserRequest);

		///<inheritdoc cref="ReactionsClient.RemoveAsync"/>
		public Task<SlackBaseResponse> RemoveReactionAsync(ReactionToRemove reactionToRemove)
			=> Reactions.RemoveAsync(reactionToRemove);

		#endregion

		#region Team

		///<inheritdoc cref="TeamClient.InfoAsync"/>
		public Task<TeamInfoResponse> TeamInfoAsync(TeamInfoRequest teamInfoRequest)
			=> Team.InfoAsync(teamInfoRequest);

		#endregion

		#region TeamProfile

		///<inheritdoc cref="TeamProfileClient.GetAsync"/>
		public Task<TeamProfileResponse> TeamProfileAsync(TeamProfileRequest teamProfileRequest)
			=> TeamProfile.GetAsync(teamProfileRequest);

		#endregion

		#region UserGroup

		///<inheritdoc cref="UserGroupsClient.CreateAsync"/>
		public Task<UserGroupResponse> CreateUserGroupAsync(UserGroupToCreate userGroup)
			=> UserGroups.CreateAsync(userGroup);

		///<inheritdoc cref="UserGroupsClient.DisableAsync"/>
		public Task<UserGroupResponse> DisableUserGroupAsync(UserGroupToDisable userGroupToDisable)
			=> UserGroups.DisableAsync(userGroupToDisable);

		///<inheritdoc cref="UserGroupsClient.EnableAsync"/>
		public Task<UserGroupResponse> EnableUserGroupAsync(UserGroupToEnable userGroupToEnable)
			=> UserGroups.EnableAsync(userGroupToEnable);

		///<inheritdoc cref="UserGroupsClient.ListAsync"/>
		public Task<UserGroupListResponse> UserGroupListAsync(UserGroupListRequest userGroupListRequest)
			=> UserGroups.ListAsync(userGroupListRequest);

		///<inheritdoc cref="UserGroupsClient.UpdateAsync"/>
		public Task<UserGroupResponse> UpdateUserGroupAsync(UserGroupToUpdate userGroupToUpdate)
			=> UserGroups.UpdateAsync(userGroupToUpdate);
		
		#endregion

		#region UserGroupUser

		///<inheritdoc cref="UserGroupsUsersClient.ListAsync"/>
		public Task<UserGroupUserListResponse> UserGroupUserListAsync(UserGroupUserListRequest userGroupUserListRequest)
			=> UserGroupsUsers.ListAsync(userGroupUserListRequest);

		///<inheritdoc cref="UserGroupsUsersClient.UpdateAsync"/>
		public Task<UserGroupResponse> UpdateUsersInUserGroupAsync(UpdateUsersInUserGroupRequest updateUsersInUserGroupRequest)
			=> UserGroupsUsers.UpdateAsync(updateUsersInUserGroupRequest);
		
		#endregion

		#region User

		///<inheritdoc cref="UsersClient.ConversationsAsync"/>
		public Task<ConversationListResponse> UserConversationsAsync(UserConversations userConversations)
			=> Users.ConversationsAsync(userConversations);

		///<inheritdoc cref="UsersClient.GetPresenceAsync"/>
		public Task<UserPresenceResponse> UserPresenceAsync(UserPresenceRequest userPresenceRequest)
			=> Users.GetPresenceAsync(userPresenceRequest);

		///<inheritdoc cref="UsersClient.InfoAsync"/>
		public Task<UserResponse> UserInfoAsync(UserToGetInfo userToGetInfo)
			=> Users.InfoAsync(userToGetInfo);

		///<inheritdoc cref="UsersClient.ListAsync"/>
		public Task<UserListResponse> UserListAsync(UserListRequest userListRequest)
			=> Users.ListAsync(userListRequest);

		///<inheritdoc cref="UsersClient.LookupByEmailAsync"/>
		public Task<UserResponse> UserByEmailAsync(UserByEmailRequest userByEmailRequest)
			=> Users.LookupByEmailAsync(userByEmailRequest);

		///<inheritdoc cref="UsersClient.SetPresenceAsync"/>
		public Task<SlackBaseResponse> SetUserPresenceAsync(SetUserPresenceRequest setUserPresenceRequest)
			=> Users.SetPresenceAsync(setUserPresenceRequest);
		
		#endregion

		#region UserProfile

		///<inheritdoc cref="UsersProfileClient.GetAsync"/>
		public Task<UserProfileResponse> UserProfileAsync(UserProfileRequest userProfileRequest)
			=> UsersProfile.GetAsync(userProfileRequest);
		
		#endregion

		protected override void DisposeObjects()
			=> _httpClient?.Dispose();
	}
}