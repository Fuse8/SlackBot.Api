using System.Net.Http;
using System.Threading.Tasks;
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
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Clients
{
	public class ConversationsClient : SlackClientBase
	{
		public ConversationsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "conversations";
		
		/// <summary>
		/// Archives a conversation.
		/// </summary>
        public Task<SlackBaseResponse> ArchiveAsync(ConversationToArchive conversationToArchive) 
            => SendPostFormUrlEncodedAsync("archive", conversationToArchive);
		
		/// <summary>
		/// Closes a direct message or multi-person direct message.
		/// </summary>
        public Task<ClosedConversationResponse> CloseAsync(ConversationToClose conversationToClose) 
            => SendPostFormUrlEncodedAsync<ConversationToClose, ClosedConversationResponse>("close", conversationToClose);
		
		/// <summary>
		/// Initiates a public or private channel-based conversation.
		/// </summary>
        public Task<ConversationResponse> CreateAsync(ChannelToCreate channelToCreate) 
            => SendPostFormUrlEncodedAsync<ChannelToCreate, ConversationResponse>("create", channelToCreate);
		
		/// <summary>
		/// Fetches a conversation's history of messages and events.
		/// </summary>
        public Task<ConversationsHistoryResponse> HistoryAsync(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("history", conversationsHistory);
		
		/// <summary>
		/// Retrieve information about a conversation.
		/// </summary>
        public Task<ConversationResponse> InfoAsync(ConversationToGetInfo conversationToGetInfo) 
            => SendGetAsync<ConversationToGetInfo, ConversationResponse>("info", conversationToGetInfo);
		
		/// <summary>
		/// Invites users to a channel.
		/// </summary>
        public Task<ConversationResponse> InviteAsync(ConversationToInvite conversationToInvite) 
            => SendPostFormUrlEncodedAsync<ConversationToInvite, ConversationResponse>("invite", conversationToInvite);
		
		/// <summary>
		/// Joins an existing conversation.
		/// </summary>
        public Task<JoinToConversationResponse> JoinAsync(ConversationToJoin conversationToJoin) 
            => SendPostFormUrlEncodedAsync<ConversationToJoin, JoinToConversationResponse>("join", conversationToJoin);
		
		/// <summary>
		/// Removes a user from a conversation.
		/// </summary>
        public Task<SlackBaseResponse> KickAsync(KickFromConversationRequest kickFromConversationRequest) 
            => SendPostFormUrlEncodedAsync<KickFromConversationRequest, SlackBaseResponse>("kick", kickFromConversationRequest);
		
		/// <summary>
		/// Leaves a conversation.
		/// </summary>
        public Task<LeaveConversationResponse> LeaveAsync(ConversationToLeave conversationToLeave) 
            => SendPostFormUrlEncodedAsync<ConversationToLeave, LeaveConversationResponse>("leave", conversationToLeave);
		
		/// <summary>
		/// Lists all channels in a Slack team.
		/// </summary>
        public Task<ConversationListResponse> ListAsync(ConversationListRequest conversationListRequest) 
            => SendGetAsync<ConversationListRequest, ConversationListResponse>("list", conversationListRequest);
		
		/// <summary>
		/// Retrieve members of a conversation.
		/// </summary>
        public Task<ConversationMembersResponse> MembersAsync(ConversationMembersRequest conversationMembersRequest) 
            => SendGetAsync<ConversationMembersRequest, ConversationMembersResponse>("members", conversationMembersRequest);
		
		/// <summary>
		/// Opens or resumes a direct message or multi-person direct message.
		/// </summary>
        public Task<OpenedConversationResponse> OpenAsync(ConversationToOpen conversationToOpen) 
            => SendPostFormUrlEncodedAsync<ConversationToOpen, OpenedConversationResponse>("open", conversationToOpen);
		
		/// <summary>
		/// Renames a conversation.
		/// </summary>
        public Task<ConversationResponse> RenameAsync(ConversationToRename conversationToRename) 
            => SendPostFormUrlEncodedAsync<ConversationToRename, ConversationResponse>("rename", conversationToRename);
		
		/// <summary>
		/// Retrieve a thread of messages posted to a conversation.
		/// </summary>
        public Task<ConversationRepliesResponse> RepliesAsync(ConversationRepliesRequest conversationRepliesRequest) 
            => SendGetAsync<ConversationRepliesRequest, ConversationRepliesResponse>("replies", conversationRepliesRequest);
		
		/// <summary>
		/// Sets the purpose for a conversation.
		/// </summary>
        public Task<ConversationResponse> SetPurposeAsync(ConversationPurposeRequest conversationPurposeRequest) 
            => SendPostFormUrlEncodedAsync<ConversationPurposeRequest, ConversationResponse>("setPurpose", conversationPurposeRequest);
		
		/// <summary>
		/// Sets the topic for a conversation.
		/// </summary>
        public Task<ConversationResponse> SetTopicAsync(ConversationTopicRequest conversationTopicRequest) 
            => SendPostFormUrlEncodedAsync<ConversationTopicRequest, ConversationResponse>("setTopic", conversationTopicRequest);
		
		/// <summary>
		/// Reverses conversation archival.
		/// </summary>
        public Task<SlackBaseResponse> UnarchiveAsync(ConversationToUnarchive conversationToUnarchive) 
            => SendPostFormUrlEncodedAsync("unarchive", conversationToUnarchive);
	}
}