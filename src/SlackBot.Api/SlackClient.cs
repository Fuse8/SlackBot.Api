using System.Threading.Tasks;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
using SlackBot.Api.Models.Chat.PostMessage;

namespace SlackBot.Api
{
    public class SlackClient : SlackClientBase
    {
        public SlackClient(string token)
            : base(token)
        {
        }

        public Task<UploadFileResponse> UploadContent(ContentToUpload contentToUpload) 
            => SendPostMultipartFormAsync<ContentToUpload, UploadFileResponse>("files.upload", contentToUpload);

        public Task<UploadFileResponse> UploadFile(FileToUpload fileToUpload) 
            => SendPostMultipartFormAsync<FileToUpload, UploadFileResponse>("files.upload", fileToUpload);
        
        public Task<PostMessageResponse> PostMessage(Message message) 
            => SendPostJsonStringAsync<Message, PostMessageResponse>("chat.postMessage", message);

        public Task<ConversationResponse> UserConversations(UserConversations userConversation) 
            => SendGetAsync<UserConversations, ConversationResponse>("users.conversations", userConversation);
        
        public Task<ConversationsHistoryResponse> ConversationsHistory(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("conversations.history", conversationsHistory);

    }
}
