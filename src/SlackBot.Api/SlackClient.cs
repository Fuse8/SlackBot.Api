using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models;
using SlackBot.Api.Models.Chat.DeleteScheduledMessage.Request;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.Chat.ScheduleMessage.Request;
using SlackBot.Api.Models.Chat.ScheduleMessage.Response;
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

		/// <summary>
		/// Deletes a pending scheduled message from the queue.
		/// </summary>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(DeleteScheduledMessageRequest deleteScheduledMessageRequest)
			=> SendPostJsonStringAsync<DeleteScheduledMessageRequest, SlackBaseResponse>("chat.deleteScheduledMessage", deleteScheduledMessageRequest);

		/// <summary>
		/// Sends a message to a channel.
		/// </summary>
		public Task<PostMessageResponse> PostMessageAsync(Message message)
			=> SendPostJsonStringAsync<Message, PostMessageResponse>("chat.postMessage", message);
		
		/// <summary>
		/// Schedules a message to be sent to a channel.
		/// </summary>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(ScheduledMessage scheduledMessage)
			=> SendPostJsonStringAsync<ScheduledMessage, ScheduleMessageResponse>("chat.scheduleMessage", scheduledMessage);

		/// <summary>
		/// Gets conversations list the calling user may access.
		/// </summary>
		public Task<ConversationResponse> UserConversationsAsync(UserConversations message)
			=> SendGetAsync<UserConversations, ConversationResponse>("users.conversations", message);
        
		/// <summary>
		/// Fetches a conversation's history of messages and events.
		/// </summary>
        public Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("conversations.history", conversationsHistory);
	}
}