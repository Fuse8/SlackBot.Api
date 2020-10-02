using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class ConversationsClient : SlackClientBase
	{
		public ConversationsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "conversations";
		
		/// <inheritdoc cref="ArchiveAsync(ConversationToArchive)"/>
        public Task<SlackBaseResponse> ArchiveAsync(string channelId) 
            => ArchiveAsync(new ConversationToArchive(channelId));
		
		/// <summary>
		/// Archives a conversation.
		/// </summary>
        public Task<SlackBaseResponse> ArchiveAsync(ConversationToArchive conversationToArchive) 
            => SendPostFormUrlEncodedAsync("archive", conversationToArchive);
		
		/// <inheritdoc cref="CloseAsync(ConversationToClose)"/>
        public Task<ClosedConversationResponse> CloseAsync(string channelId) 
            => CloseAsync(new ConversationToClose(channelId));
		
		/// <summary>
		/// Closes a direct message or multi-person direct message.
		/// </summary>
        public Task<ClosedConversationResponse> CloseAsync(ConversationToClose conversationToClose) 
            => SendPostFormUrlEncodedAsync<ConversationToClose, ClosedConversationResponse>("close", conversationToClose);
		
		/// <inheritdoc cref="CreateAsync(ChannelToCreate)"/>
        public Task<ConversationResponse> CreateAsync(string name, bool? isPrivate = null) 
            => CreateAsync(new ChannelToCreate(name, isPrivate));
		
		/// <summary>
		/// Initiates a public or private channel-based conversation.
		/// </summary>
        public Task<ConversationResponse> CreateAsync(ChannelToCreate channelToCreate) 
            => SendPostFormUrlEncodedAsync<ChannelToCreate, ConversationResponse>("create", channelToCreate);
		
		/// <inheritdoc cref="HistoryAsync(ConversationsHistory)"/>
        public Task<ConversationsHistoryResponse> HistoryAsync(string channelId, long? limit = null, string cursor = null) 
            => HistoryAsync(new ConversationsHistory(channelId, limit, cursor));
		
		/// <inheritdoc cref="HistoryAsync(ConversationsHistory)"/>
        public Task<ConversationsHistoryResponse> HistoryAsync(string channelId, string latest, bool? inclusive = true, long? limit = 1) 
            => HistoryAsync(new ConversationsHistory(channelId, latest, inclusive, limit));
		
		/// <summary>
		/// Fetches a conversation's history of messages and events.
		/// </summary>
        public Task<ConversationsHistoryResponse> HistoryAsync(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("history", conversationsHistory);
		
		/// <inheritdoc cref="InfoAsync(ConversationToGetInfo)"/>
        public Task<ConversationResponse> InfoAsync(string channelId, bool? includeLocale = null, bool? includeMemberCount = null) 
            => InfoAsync(new ConversationToGetInfo(channelId, includeLocale, includeMemberCount));
		
		/// <summary>
		/// Retrieve information about a conversation.
		/// </summary>
        public Task<ConversationResponse> InfoAsync(ConversationToGetInfo conversationToGetInfo) 
            => SendGetAsync<ConversationToGetInfo, ConversationResponse>("info", conversationToGetInfo);
		
		/// <inheritdoc cref="InviteAsync(ConversationToInvite)"/>
        public Task<ConversationResponse> InviteAsync(string channelId, string userIds) 
            => InviteAsync(new ConversationToInvite(channelId, userIds));
		
		/// <summary>
		/// Invites users to a channel.
		/// </summary>
        public Task<ConversationResponse> InviteAsync(ConversationToInvite conversationToInvite) 
            => SendPostFormUrlEncodedAsync<ConversationToInvite, ConversationResponse>("invite", conversationToInvite);
		
		/// <inheritdoc cref="JoinAsync(ConversationToJoin)"/>
        public Task<JoinToConversationResponse> JoinAsync(string channelId) 
            => JoinAsync(new ConversationToJoin(channelId));
		
		/// <summary>
		/// Joins an existing conversation.
		/// </summary>
        public Task<JoinToConversationResponse> JoinAsync(ConversationToJoin conversationToJoin) 
            => SendPostFormUrlEncodedAsync<ConversationToJoin, JoinToConversationResponse>("join", conversationToJoin);
		
		/// <inheritdoc cref="KickAsync(KickFromConversationRequest)"/>
        public Task<SlackBaseResponse> KickAsync(string channelId, string userId) 
            => KickAsync(new KickFromConversationRequest(channelId, userId));
		
		/// <summary>
		/// Removes a user from a conversation.
		/// </summary>
        public Task<SlackBaseResponse> KickAsync(KickFromConversationRequest kickFromConversationRequest) 
            => SendPostFormUrlEncodedAsync<KickFromConversationRequest, SlackBaseResponse>("kick", kickFromConversationRequest);
		
		/// <inheritdoc cref="LeaveAsync(ConversationToLeave)"/>
        public Task<LeaveConversationResponse> LeaveAsync(string channelId) 
            => LeaveAsync(new ConversationToLeave(channelId));
		
		/// <summary>
		/// Leaves a conversation.
		/// </summary>
        public Task<LeaveConversationResponse> LeaveAsync(ConversationToLeave conversationToLeave) 
            => SendPostFormUrlEncodedAsync<ConversationToLeave, LeaveConversationResponse>("leave", conversationToLeave);
		
		/// <inheritdoc cref="ListAsync(ConversationListRequest)"/>
        public Task<ConversationObjectListResponse> ListAsync(string types = null, string cursor = null, long? limit = null) 
            => ListAsync(new ConversationListRequest(types, cursor, limit));
		
		/// <summary>
		/// Lists all channels in a Slack team.
		/// </summary>
        public Task<ConversationObjectListResponse> ListAsync(ConversationListRequest conversationListRequest) 
            => SendGetAsync<ConversationListRequest, ConversationObjectListResponse>("list", conversationListRequest);
		
		/// <inheritdoc cref="MembersAsync(ConversationMembersRequest)"/>
        public Task<ConversationMembersResponse> MembersAsync(string channelId, string cursor = null, long? limit = null) 
            => MembersAsync(new ConversationMembersRequest(channelId, cursor, limit));
		
		/// <summary>
		/// Retrieve members of a conversation.
		/// </summary>
        public Task<ConversationMembersResponse> MembersAsync(ConversationMembersRequest conversationMembersRequest) 
            => SendGetAsync<ConversationMembersRequest, ConversationMembersResponse>("members", conversationMembersRequest);
		
		/// <inheritdoc cref="OpenAsync(ConversationToOpen)"/>
        public Task<OpenedConversationResponse> OpenAsync(string userIds, bool? returnFullDirectMessageInfo = null) 
            => OpenAsync(new ConversationToOpen(userIds, returnFullDirectMessageInfo));
		
		/// <summary>
		/// Opens or resumes a direct message or multi-person direct message.
		/// </summary>
        public Task<OpenedConversationResponse> OpenAsync(ConversationToOpen conversationToOpen) 
            => SendPostFormUrlEncodedAsync<ConversationToOpen, OpenedConversationResponse>("open", conversationToOpen);
		
		/// <inheritdoc cref="RenameAsync(ConversationToRename)"/>
        public Task<ConversationResponse> RenameAsync(string channelId, string name) 
            => RenameAsync(new ConversationToRename(channelId, name));
		
		/// <summary>
		/// Renames a conversation.
		/// </summary>
        public Task<ConversationResponse> RenameAsync(ConversationToRename conversationToRename) 
            => SendPostFormUrlEncodedAsync<ConversationToRename, ConversationResponse>("rename", conversationToRename);
		
		/// <inheritdoc cref="RepliesAsync(ConversationRepliesRequest)"/>
        public Task<ConversationRepliesResponse> RepliesAsync(string channelId, string messageTimestamp, string cursor = null, long? limit = null, string oldest = null, string latest = null) 
            => RepliesAsync(new ConversationRepliesRequest(channelId, messageTimestamp, cursor, limit, oldest, latest));
		
		/// <summary>
		/// Retrieve a thread of messages posted to a conversation.
		/// </summary>
        public Task<ConversationRepliesResponse> RepliesAsync(ConversationRepliesRequest conversationRepliesRequest) 
            => SendGetAsync<ConversationRepliesRequest, ConversationRepliesResponse>("replies", conversationRepliesRequest);
		
		/// <inheritdoc cref="SetPurposeAsync(ConversationPurposeRequest)"/>
        public Task<ConversationResponse> SetPurposeAsync(string channelId, string purpose) 
            => SetPurposeAsync(new ConversationPurposeRequest(channelId, purpose));
		
		/// <summary>
		/// Sets the purpose for a conversation.
		/// </summary>
        public Task<ConversationResponse> SetPurposeAsync(ConversationPurposeRequest conversationPurposeRequest) 
            => SendPostFormUrlEncodedAsync<ConversationPurposeRequest, ConversationResponse>("setPurpose", conversationPurposeRequest);
		
		/// <inheritdoc cref="SetTopicAsync(ConversationTopicRequest)"/>
        public Task<ConversationResponse> SetTopicAsync(string channelId, string topic) 
            => SetTopicAsync(new ConversationTopicRequest(channelId, topic));
		
		/// <summary>
		/// Sets the topic for a conversation.
		/// </summary>
        public Task<ConversationResponse> SetTopicAsync(ConversationTopicRequest conversationTopicRequest) 
            => SendPostFormUrlEncodedAsync<ConversationTopicRequest, ConversationResponse>("setTopic", conversationTopicRequest);
		
		/// <inheritdoc cref="UnarchiveAsync(ConversationToUnarchive)"/>
		public Task<SlackBaseResponse> UnarchiveAsync(string channelId) 
            => UnarchiveAsync(new ConversationToUnarchive(channelId));
		
		/// <summary>
		/// Reverses conversation archival.
		/// </summary>
        public Task<SlackBaseResponse> UnarchiveAsync(ConversationToUnarchive conversationToUnarchive) 
            => SendPostFormUrlEncodedAsync("unarchive", conversationToUnarchive);
	}
}