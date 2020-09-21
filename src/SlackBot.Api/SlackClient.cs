using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models;
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
		/// Deletes a message.
		/// </summary>
		public Task<DeletedMessageResponse> DeleteMessageAsync(MessageToDelete messageToDelete)
			=> SendPostFormUrlEncodedAsync<MessageToDelete, DeletedMessageResponse>("chat.delete", messageToDelete);

		/// <summary>
		/// Deletes a pending scheduled message from the queue.
		/// </summary>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(DeleteScheduledMessageRequest deleteScheduledMessageRequest)
			=> SendPostJsonStringAsync<DeleteScheduledMessageRequest, SlackBaseResponse>("chat.deleteScheduledMessage", deleteScheduledMessageRequest);

		/// <summary>
		/// Retrieve a permalink URL for a specific extant message.
		/// </summary>
		public Task<GetPermalinkResponse> GetMessagePermalinkAsync(GetPermalinkRequest getPermalinkRequest)
			=> SendGetAsync<GetPermalinkRequest, GetPermalinkResponse>("chat.getPermalink", getPermalinkRequest);

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
		public Task<ScheduledMessagesResponse> GetScheduledMessages(GetScheduledMessagesRequest getScheduledMessagesRequest)
			=> SendPostFormUrlEncodedAsync<GetScheduledMessagesRequest, ScheduledMessagesResponse>("chat.scheduledMessages.list", getScheduledMessagesRequest);
		
		/// <summary>
		/// Updates a message.
		/// </summary>
		public Task<UpdateMessageResponse> UpdateMessage(MessageToUpdate messageToUpdate)
			=> SendPostJsonStringAsync<MessageToUpdate, UpdateMessageResponse>("chat.update", messageToUpdate);

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