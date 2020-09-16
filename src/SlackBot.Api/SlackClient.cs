using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;

namespace SlackBot.Api
{
    public class SlackClient : SlackClientBase
	{
		public SlackClient(HttpClient httpClient)
            : base(httpClient)
		{
		}

		public Task<UploadFileResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> SendPostMultipartFormAsync<ContentToUpload, UploadFileResponse>("files.upload", contentToUpload);

		public Task<UploadFileResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> SendPostMultipartFormAsync<FileToUpload, UploadFileResponse>("files.upload", fileToUpload);

		public Task<PostMessageResponse> PostMessageAsync(Message message)
			=> SendPostJsonStringAsync<Message, PostMessageResponse>("chat.postMessage", message);

		public Task<ConversationResponse> UserConversationsAsync(UserConversations message)
			=> SendGetAsync<UserConversations, ConversationResponse>("users.conversations", message);
        
        public Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("conversations.history", conversationsHistory);
	}
}