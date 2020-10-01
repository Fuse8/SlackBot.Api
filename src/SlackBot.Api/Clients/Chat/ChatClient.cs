using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Clients.Delete.Request;
using SlackBot.Api.Clients.Delete.Response;
using SlackBot.Api.Clients.DeleteScheduledMessage.Request;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GetPermalink.Request;
using SlackBot.Api.Clients.GetPermalink.Response;
using SlackBot.Api.Clients.PostEphemeral.Request;
using SlackBot.Api.Clients.PostEphemeral.Response;
using SlackBot.Api.Clients.PostMessage;
using SlackBot.Api.Clients.PostMessage.Response;
using SlackBot.Api.Clients.ScheduledMessagesList.Request;
using SlackBot.Api.Clients.ScheduledMessagesList.Response;
using SlackBot.Api.Clients.ScheduleMessage.Request;
using SlackBot.Api.Clients.ScheduleMessage.Response;
using SlackBot.Api.Clients.Update.Request;
using SlackBot.Api.Clients.Update.Response;

namespace SlackBot.Api.Clients
{
	public class ChatClient : SlackClientBase
	{
		public ChatClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "chat";

		/// <summary>
		/// Deletes a message.
		/// </summary>
		public Task<DeletedMessageResponse> DeleteAsync(MessageToDelete messageToDelete)
			=> SendPostFormUrlEncodedAsync<MessageToDelete, DeletedMessageResponse>("delete", messageToDelete);

		/// <summary>
		/// Deletes a pending scheduled message from the queue.
		/// </summary>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(ScheduledMessageToDelete scheduledMessageToDelete)
			=> SendPostJsonStringAsync("deleteScheduledMessage", scheduledMessageToDelete);

		/// <summary>
		/// Retrieve a permalink URL for a specific extant message.
		/// </summary>
		public Task<MessagePermalinkResponse> GetPermalinkAsync(MessageToGetPermalink messageToGetPermalink)
			=> SendGetAsync<MessageToGetPermalink, MessagePermalinkResponse>("getPermalink", messageToGetPermalink);

		/// <summary>
		/// Sends an ephemeral message to a user in a channel.
		/// </summary>
		public Task<SendEphemeralMessageResponse> PostEphemeralAsync(EphemeralMessage ephemeralMessage)
			=> SendPostJsonStringAsync<EphemeralMessage, SendEphemeralMessageResponse>("postEphemeral", ephemeralMessage);

		/// <summary>
		/// Sends a message to a channel.
		/// </summary>
		public Task<SendMessageResponse> PostMessageAsync(Message message)
			=> SendPostJsonStringAsync<Message, SendMessageResponse>("postMessage", message);
		
		/// <summary>
		/// Schedules a message to be sent to a channel.
		/// </summary>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(MessageToSchedule messageToSchedule)
			=> SendPostJsonStringAsync<MessageToSchedule, ScheduleMessageResponse>("scheduleMessage", messageToSchedule);
		
		/// <summary>
		/// Returns a list of scheduled messages.
		/// </summary>
		public Task<ScheduledMessageListResponse> ScheduledMessagesListAsync(ScheduledMessageListRequest scheduledMessageListRequest)
			=> SendPostFormUrlEncodedAsync<ScheduledMessageListRequest, ScheduledMessageListResponse>("scheduledMessages.list", scheduledMessageListRequest);
		
		/// <summary>
		/// Updates a message.
		/// </summary>
		public Task<UpdateMessageResponse> UpdateAsync(MessageToUpdate messageToUpdate)
			=> SendPostJsonStringAsync<MessageToUpdate, UpdateMessageResponse>("update", messageToUpdate);
	}
}