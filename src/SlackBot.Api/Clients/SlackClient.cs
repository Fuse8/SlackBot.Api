using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Helpers;

namespace SlackBot.Api
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
		
		public BotsClient Bots => GetOrCreateClient(ref _botsClient);
		
		public EmojiClient Emoji => GetOrCreateClient(ref _emojiClient);
		
		public FilesClient Files => GetOrCreateClient(ref _filesClient);
		
		public FilesRemoteClient FilesRemote => GetOrCreateClient(ref _filesRemoteClient);

		public ChatClient Chat => GetOrCreateClient(ref _chatClient);
		
		public ConversationsClient Conversations => GetOrCreateClient(ref _conversationsClient);
		
		public PinsClient Pins => GetOrCreateClient(ref _pinsClient);
		
		public ReactionsClient Reactions => GetOrCreateClient(ref _reactionsClient);
		
		public TeamClient Team => GetOrCreateClient(ref _teamClient);
		
		public TeamProfileClient TeamProfile => GetOrCreateClient(ref _teamProfileClient);
		
		public UserGroupsClient UserGroups => GetOrCreateClient(ref _userGroupsClient);
		
		public UserGroupsUsersClient UserGroupsUsers => GetOrCreateClient(ref _userGroupsUsersClient);

		public UsersClient Users => GetOrCreateClient(ref _usersClient);

		public UsersProfileClient UsersProfile => GetOrCreateClient(ref _usersProfileClient);
		
		#endregion

		#region Bots
		
		/// <inheritdoc cref="BotsClient.InfoAsync(BotInfoRequest)"/>
		public Task<BotInfoResponse> GetBotInfoAsync(BotInfoRequest botInfoRequest)
			=> Bots.InfoAsync(botInfoRequest);
		
		#endregion

		#region Emoji
		
		/// <inheritdoc cref="EmojiClient.ListAsync"/>
		public Task<EmojiListResponse> EmojiListAsync()
			=> Emoji.ListAsync();

		#endregion
		
		#region Files
		
		/// <inheritdoc cref="FilesClient.DeleteAsync(FileToDelete)"/>
		public Task<SlackBaseResponse> DeleteFileAsync(FileToDelete fileToDelete)
			=> Files.DeleteAsync(fileToDelete);
		
		/// <inheritdoc cref="FilesClient.InfoAsync(FileInfoRequest)"/>
		public Task<FileInfoResponse> FileInfoAsync(FileInfoRequest fileInfoRequest)
			=> Files.InfoAsync(fileInfoRequest);

		/// <inheritdoc cref="FilesClient.ListAsync(FileListRequest)"/>
		public Task<FileListResponse> FileListAsync(FileListRequest fileListRequest)
			=> Files.ListAsync(fileListRequest);

		/// <inheritdoc cref="FilesClient.UploadContentAsync(ContentToUpload)"/>
		public Task<FileObjectResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> Files.UploadContentAsync(contentToUpload);

		/// <inheritdoc cref="FilesClient.UploadFileAsync(FileToUpload)"/>
		public Task<FileObjectResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> Files.UploadFileAsync(fileToUpload);
		
		#endregion

		#region FilesRemote

		/// <inheritdoc cref="FilesRemoteClient.AddAsync(RemoteFile)"/>
		public Task<FileObjectResponse> AddRemoteFileAsync(RemoteFile remoteFile)
			=> FilesRemote.AddAsync(remoteFile);

		/// <inheritdoc cref="FilesRemoteClient.InfoAsync(RemoteFileInfoRequest)"/>
		public Task<FileObjectResponse> RemoteFileInfoAsync(RemoteFileInfoRequest remoteFileInfoRequest)
			=> FilesRemote.InfoAsync(remoteFileInfoRequest);

		/// <inheritdoc cref="FilesRemoteClient.ListAsync(RemoteFileListRequest)"/>
		public Task<RemoteFileListResponse> RemoteFileListAsync(RemoteFileListRequest remoteFileListRequest)
			=> FilesRemote.ListAsync(remoteFileListRequest);

		/// <inheritdoc cref="FilesRemoteClient.RemoveAsync(RemoteFileToRemove)"/>
		public Task<SlackBaseResponse> RemoveRemoteFileAsync(RemoteFileToRemove remoteFileToRemove)
			=> FilesRemote.RemoveAsync(remoteFileToRemove);

		/// <inheritdoc cref="FilesRemoteClient.ShareAsync(RemoteFileToShare)"/>
		public Task<FileObjectResponse> ShareRemoteFileAsync(RemoteFileToShare remoteFileToShare)
			=> FilesRemote.ShareAsync(remoteFileToShare);

		/// <inheritdoc cref="FilesRemoteClient.UpdateAsync(RemoteFileToUpdate)"/>
		public Task<FileObjectResponse> UpdateRemoteFileAsync(RemoteFileToUpdate remoteFileToUpdate)
			=> FilesRemote.UpdateAsync(remoteFileToUpdate);

		#endregion
		
		#region Chat

		/// <inheritdoc cref="ChatClient.DeleteAsync(MessageToDelete)"/>
		public Task<DeletedMessageResponse> DeleteMessageAsync(MessageToDelete messageToDelete)
			=> Chat.DeleteAsync(messageToDelete);

		/// <inheritdoc cref="ChatClient.DeleteScheduledMessageAsync(ScheduledMessageToDelete)"/>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(ScheduledMessageToDelete scheduledMessageToDelete)
			=> Chat.DeleteScheduledMessageAsync(scheduledMessageToDelete);

		/// <inheritdoc cref="ChatClient.GetPermalinkAsync(MessageToGetPermalink)"/>
		public Task<MessagePermalinkResponse> GetMessagePermalinkAsync(MessageToGetPermalink messageToGetPermalink)
			=> Chat.GetPermalinkAsync(messageToGetPermalink);

		/// <inheritdoc cref="ChatClient.PostEphemeralAsync(EphemeralMessage)"/>
		public Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync(EphemeralMessage ephemeralMessage)
			=> Chat.PostEphemeralAsync(ephemeralMessage);

		/// <inheritdoc cref="ChatClient.PostMessageAsync(SlackMessage)"/>
		public Task<SendMessageResponse> SendMessageAsync(SlackMessage slackMessage)
			=> Chat.PostMessageAsync(slackMessage);
		
		/// <inheritdoc cref="ChatClient.ScheduleMessageAsync(MessageToSchedule)"/>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(MessageToSchedule messageToSchedule)
			=> Chat.ScheduleMessageAsync(messageToSchedule);
		
		/// <inheritdoc cref="ChatClient.ScheduledMessagesListAsync(ScheduledMessageListRequest)"/>
		public Task<ScheduledMessageListResponse> GetScheduledMessagesAsync(ScheduledMessageListRequest scheduledMessageListRequest)
			=> Chat.ScheduledMessagesListAsync(scheduledMessageListRequest);
		
		/// <inheritdoc cref="ChatClient.UpdateAsync(MessageToUpdate)"/>
		public Task<UpdateMessageResponse> UpdateMessageAsync(MessageToUpdate messageToUpdate)
			=> Chat.UpdateAsync(messageToUpdate);
		
		#endregion
        
		#region Conversations

		/// <inheritdoc cref="ConversationsClient.ArchiveAsync(ConversationToArchive)"/>
		public Task<SlackBaseResponse> ArchiveConversationAsync(ConversationToArchive conversationToArchive)
			=> Conversations.ArchiveAsync(conversationToArchive);
		
		/// <inheritdoc cref="ConversationsClient.CloseAsync(ConversationToClose)"/>
        public Task<ClosedConversationResponse> CloseConversationAsync(ConversationToClose conversationToClose) 
            => Conversations.CloseAsync(conversationToClose);
		
		/// <inheritdoc cref="ConversationsClient.CreateAsync(ChannelToCreate)"/>
        public Task<ConversationResponse> CreateChannelAsync(ChannelToCreate channelToCreate) 
            => Conversations.CreateAsync(channelToCreate);
		
		/// <inheritdoc cref="ConversationsClient.HistoryAsync(ConversationsHistory)"/>
        public Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistory conversationsHistory) 
            => Conversations.HistoryAsync(conversationsHistory);
		
		/// <inheritdoc cref="ConversationsClient.InfoAsync(ConversationToGetInfo)"/>
        public Task<ConversationResponse> ConversationInfoAsync(ConversationToGetInfo conversationToGetInfo) 
            => Conversations.InfoAsync(conversationToGetInfo);
		
		/// <inheritdoc cref="ConversationsClient.InviteAsync(ConversationToInvite)"/>
        public Task<ConversationResponse> InviteToConversationAsync(ConversationToInvite conversationToInvite) 
            => Conversations.InviteAsync(conversationToInvite);
		
		/// <inheritdoc cref="ConversationsClient.JoinAsync(ConversationToJoin)"/>
        public Task<JoinToConversationResponse> JoinToConversationAsync(ConversationToJoin conversationToJoin) 
            => Conversations.JoinAsync(conversationToJoin);
		
		/// <inheritdoc cref="ConversationsClient.KickAsync(KickFromConversationRequest)"/>
        public Task<SlackBaseResponse> KickFromConversationAsync(KickFromConversationRequest kickFromConversationRequest) 
            => Conversations.KickAsync(kickFromConversationRequest);
		
		/// <inheritdoc cref="ConversationsClient.LeaveAsync(ConversationToLeave)"/>
        public Task<LeaveConversationResponse> LeaveConversationAsync(ConversationToLeave conversationToLeave) 
            => Conversations.LeaveAsync(conversationToLeave);
		
		/// <inheritdoc cref="ConversationsClient.ListAsync(ConversationListRequest)"/>
        public Task<ConversationObjectListResponse> ConversationListAsync(ConversationListRequest conversationListRequest) 
            => Conversations.ListAsync(conversationListRequest);
		
		/// <inheritdoc cref="ConversationsClient.MembersAsync(ConversationMembersRequest)"/>
        public Task<ConversationMembersResponse> ConversationMembersAsync(ConversationMembersRequest conversationMembersRequest) 
            => Conversations.MembersAsync(conversationMembersRequest);
		
		/// <inheritdoc cref="ConversationsClient.OpenAsync(ConversationToOpen)"/>
        public Task<OpenedConversationResponse> OpenConversationAsync(ConversationToOpen conversationToOpen) 
            => Conversations.OpenAsync(conversationToOpen);
		
		/// <inheritdoc cref="ConversationsClient.RenameAsync(ConversationToRename)"/>
        public Task<ConversationResponse> RenameConversationAsync(ConversationToRename conversationToRename) 
            => Conversations.RenameAsync(conversationToRename);
		
		/// <inheritdoc cref="ConversationsClient.RepliesAsync(ConversationRepliesRequest)"/>
        public Task<ConversationRepliesResponse> ConversationRepliesAsync(ConversationRepliesRequest conversationRepliesRequest) 
            => Conversations.RepliesAsync(conversationRepliesRequest);
		
		/// <inheritdoc cref="ConversationsClient.SetPurposeAsync(ConversationPurposeRequest)"/>
        public Task<ConversationResponse> SetConversationPurposeAsync(ConversationPurposeRequest conversationPurposeRequest) 
            => Conversations.SetPurposeAsync(conversationPurposeRequest);
		
		/// <inheritdoc cref="ConversationsClient.SetTopicAsync(ConversationTopicRequest)"/>
        public Task<ConversationResponse> SetConversationTopicAsync(ConversationTopicRequest conversationTopicRequest) 
            => Conversations.SetTopicAsync(conversationTopicRequest);
		
		/// <inheritdoc cref="ConversationsClient.UnarchiveAsync(ConversationToUnarchive)"/>
        public Task<SlackBaseResponse> UnarchiveConversationAsync(ConversationToUnarchive conversationToUnarchive) 
            => Conversations.UnarchiveAsync(conversationToUnarchive);
		
		#endregion

		#region Pins

		/// <inheritdoc cref="PinsClient.PinAsync(PinItem)"/>
		public Task<SlackBaseResponse> PinMessageAsync(PinItem pinItem)
			=> Pins.PinAsync(pinItem);

		/// <inheritdoc cref="PinsClient.ListAsync(PinListRequest)"/>
		public Task<PinListResponse> PinListAsync(PinListRequest pinListRequest)
			=> Pins.ListAsync(pinListRequest);

		/// <inheritdoc cref="PinsClient.RemoveAsync(PinItemToRemove)"/>
		public Task<SlackBaseResponse> RemovePinAsync(PinItemToRemove pinItemToRemove)
			=> Pins.RemoveAsync(pinItemToRemove);

		#endregion

		#region Reactions

		/// <inheritdoc cref="ReactionsClient.AddAsync(SlackReaction)"/>
		public Task<SlackBaseResponse> AddReactionAsync(SlackReaction slackReaction)
			=> Reactions.AddAsync(slackReaction);

		/// <inheritdoc cref="ReactionsClient.GetAsync(ReactionsByItemRequest)"/>
		public Task<ReactionsByItemResponse> GetReactionsByItemAsync(ReactionsByItemRequest reactionsByItemRequest)
			=> Reactions.GetAsync(reactionsByItemRequest);

		/// <inheritdoc cref="ReactionsClient.ListAsync(ReactionsByUserRequest)"/>
		public Task<ReactionsByUserResponse> GetReactionsByUserAsync(ReactionsByUserRequest reactionsByUserRequest)
			=> Reactions.ListAsync(reactionsByUserRequest);

		/// <inheritdoc cref="ReactionsClient.RemoveAsync(ReactionToRemove)"/>
		public Task<SlackBaseResponse> RemoveReactionAsync(ReactionToRemove reactionToRemove)
			=> Reactions.RemoveAsync(reactionToRemove);

		#endregion

		#region Team

		/// <inheritdoc cref="TeamClient.InfoAsync(TeamInfoRequest)"/>
		public Task<TeamInfoResponse> TeamInfoAsync(TeamInfoRequest teamInfoRequest)
			=> Team.InfoAsync(teamInfoRequest);

		#endregion

		#region TeamProfile

		/// <inheritdoc cref="TeamProfileClient.GetAsync(TeamProfileRequest)"/>
		public Task<TeamProfileResponse> TeamProfileAsync(TeamProfileRequest teamProfileRequest)
			=> TeamProfile.GetAsync(teamProfileRequest);

		#endregion

		#region UserGroups

		/// <inheritdoc cref="UserGroupsClient.CreateAsync(SlackUserGroup)"/>
		public Task<UserGroupObjectResponse> CreateUserGroupAsync(SlackUserGroup slackUserGroup)
			=> UserGroups.CreateAsync(slackUserGroup);

		/// <inheritdoc cref="UserGroupsClient.DisableAsync(UserGroupToDisable)"/>
		public Task<UserGroupObjectResponse> DisableUserGroupAsync(UserGroupToDisable userGroupToDisable)
			=> UserGroups.DisableAsync(userGroupToDisable);

		/// <inheritdoc cref="UserGroupsClient.EnableAsync(UserGroupToEnable)"/>
		public Task<UserGroupObjectResponse> EnableUserGroupAsync(UserGroupToEnable userGroupToEnable)
			=> UserGroups.EnableAsync(userGroupToEnable);

		/// <inheritdoc cref="UserGroupsClient.ListAsync(UserGroupListRequest)"/>
		public Task<UserGroupListResponse> UserGroupListAsync(UserGroupListRequest userGroupListRequest)
			=> UserGroups.ListAsync(userGroupListRequest);

		/// <inheritdoc cref="UserGroupsClient.UpdateAsync(UserGroupToUpdate)"/>
		public Task<UserGroupObjectResponse> UpdateUserGroupAsync(UserGroupToUpdate userGroupToUpdate)
			=> UserGroups.UpdateAsync(userGroupToUpdate);
		
		#endregion

		#region UserGroupsUsers

		/// <inheritdoc cref="UserGroupsUsersClient.ListAsync(UserGroupUserListRequest)"/>
		public Task<UserGroupUserListResponse> UserGroupUserListAsync(UserGroupUserListRequest userGroupUserListRequest)
			=> UserGroupsUsers.ListAsync(userGroupUserListRequest);

		/// <inheritdoc cref="UserGroupsUsersClient.UpdateAsync(UpdateUsersInUserGroupRequest)"/>
		public Task<UserGroupObjectResponse> UpdateUsersInUserGroupAsync(UpdateUsersInUserGroupRequest updateUsersInUserGroupRequest)
			=> UserGroupsUsers.UpdateAsync(updateUsersInUserGroupRequest);
		
		#endregion

		#region Users

		/// <inheritdoc cref="UsersClient.ConversationsAsync(UserConversations)"/>
		public Task<ConversationObjectListResponse> UserConversationsAsync(UserConversations userConversations)
			=> Users.ConversationsAsync(userConversations);

		/// <inheritdoc cref="UsersClient.GetPresenceAsync(UserPresenceRequest)"/>
		public Task<UserPresenceResponse> UserPresenceAsync(UserPresenceRequest userPresenceRequest)
			=> Users.GetPresenceAsync(userPresenceRequest);

		/// <inheritdoc cref="UsersClient.InfoAsync(UserToGetInfo)"/>
		public Task<UserResponse> UserInfoAsync(UserToGetInfo userToGetInfo)
			=> Users.InfoAsync(userToGetInfo);

		/// <inheritdoc cref="UsersClient.ListAsync(UserListRequest)"/>
		public Task<UserListResponse> UserListAsync(UserListRequest userListRequest)
			=> Users.ListAsync(userListRequest);

		/// <inheritdoc cref="UsersClient.LookupByEmailAsync(UserByEmailRequest)"/>
		public Task<UserResponse> UserByEmailAsync(UserByEmailRequest userByEmailRequest)
			=> Users.LookupByEmailAsync(userByEmailRequest);

		/// <inheritdoc cref="UsersClient.SetPresenceAsync(SetUserPresenceRequest)"/>
		public Task<SlackBaseResponse> SetUserPresenceAsync(SetUserPresenceRequest setUserPresenceRequest)
			=> Users.SetPresenceAsync(setUserPresenceRequest);
		
		#endregion

		#region UsersProfile

		/// <inheritdoc cref="UsersProfileClient.GetAsync(UserProfileRequest)"/>
		public Task<UserProfileResponse> UserProfileAsync(UserProfileRequest userProfileRequest)
			=> UsersProfile.GetAsync(userProfileRequest);
		
		#endregion

		protected override void DisposeObjects()
			=> _httpClient?.Dispose();

		private TClient GetOrCreateClient<TClient>(ref TClient client)
			where TClient : SlackClientBase
			=> client ?? (client = SlackClientFactory.CreateClient<TClient>(_httpClient));
	}
}