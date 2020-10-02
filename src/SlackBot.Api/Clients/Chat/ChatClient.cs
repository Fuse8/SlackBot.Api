using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class ChatClient : SlackClientBase
	{
		public ChatClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "chat";

		/// <inheritdoc cref="DeleteAsync(MessageToDelete)"/>
		public Task<DeletedMessageResponse> DeleteAsync(string channelId, string messageTimestamp)
			=> DeleteAsync(new MessageToDelete(channelId, messageTimestamp));

		/// <summary>
		/// Deletes a message.
		/// </summary>
		public Task<DeletedMessageResponse> DeleteAsync(MessageToDelete messageToDelete)
			=> SendPostFormUrlEncodedAsync<MessageToDelete, DeletedMessageResponse>("delete", messageToDelete);

		/// <inheritdoc cref="DeleteScheduledMessageAsync(ScheduledMessageToDelete)"/>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(string channelId, string scheduledMessageId)
			=> DeleteScheduledMessageAsync(new ScheduledMessageToDelete(channelId, scheduledMessageId));

		/// <summary>
		/// Deletes a pending scheduled message from the queue.
		/// </summary>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(ScheduledMessageToDelete scheduledMessageToDelete)
			=> SendPostJsonStringAsync("deleteScheduledMessage", scheduledMessageToDelete);

		/// <inheritdoc cref="GetPermalinkAsync(MessageToGetPermalink)"/>
		public Task<MessagePermalinkResponse> GetPermalinkAsync(string channelId, string messageTimestamp)
			=> GetPermalinkAsync(new MessageToGetPermalink(channelId, messageTimestamp));

		/// <summary>
		/// Retrieve a permalink URL for a specific extant message.
		/// </summary>
		public Task<MessagePermalinkResponse> GetPermalinkAsync(MessageToGetPermalink messageToGetPermalink)
			=> SendGetAsync<MessageToGetPermalink, MessagePermalinkResponse>("getPermalink", messageToGetPermalink);

		/// <inheritdoc cref="PostEphemeralAsync(EphemeralMessage)"/>
		public Task<SendEphemeralMessageResponse> PostEphemeralAsync(string channelIdOrName, string userId, string text = null, List<Attachment> attachments = null, List<BlockBase> blocks = null)
			=> PostEphemeralAsync(new EphemeralMessage(channelIdOrName, userId, text, attachments, blocks));

		/// <summary>
		/// Sends an ephemeral message to a user in a channel.
		/// </summary>
		public Task<SendEphemeralMessageResponse> PostEphemeralAsync(EphemeralMessage ephemeralMessage)
			=> SendPostJsonStringAsync<EphemeralMessage, SendEphemeralMessageResponse>("postEphemeral", ephemeralMessage);

		/// <inheritdoc cref="PostMessageAsync(SlackMessage)"/>
		public Task<SendMessageResponse> PostMessageAsync(string channelIdOrName, string text = null, List<Attachment> attachments = null, List<BlockBase> blocks = null)
			=> PostMessageAsync(new SlackMessage(channelIdOrName, text, attachments, blocks));

		/// <summary>
		/// Sends a message to a channel.
		/// </summary>
		public Task<SendMessageResponse> PostMessageAsync(SlackMessage slackMessage)
			=> SendPostJsonStringAsync<SlackMessage, SendMessageResponse>("postMessage", slackMessage);
		
		/// <inheritdoc cref="ScheduleMessageAsync(MessageToSchedule)"/>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(string channelIdOrName, long postAt, string text = null, List<Attachment> attachments = null, List<BlockBase> blocks = null)
			=> ScheduleMessageAsync(new MessageToSchedule(channelIdOrName, postAt, text, attachments, blocks));
		
		/// <summary>
		/// Schedules a message to be sent to a channel.
		/// </summary>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(MessageToSchedule messageToSchedule)
			=> SendPostJsonStringAsync<MessageToSchedule, ScheduleMessageResponse>("scheduleMessage", messageToSchedule);
		
		/// <inheritdoc cref="ScheduledMessagesListAsync(ScheduledMessageListRequest)"/>
		public Task<ScheduledMessageListResponse> ScheduledMessagesListAsync(string channelId, string cursor = null, long? limit = null, string oldest = null, string latest = null)
			=> ScheduledMessagesListAsync(new ScheduledMessageListRequest(channelId, cursor, limit, oldest, latest));
		
		/// <summary>
		/// Returns a list of scheduled messages.
		/// </summary>
		public Task<ScheduledMessageListResponse> ScheduledMessagesListAsync(ScheduledMessageListRequest scheduledMessageListRequest)
			=> SendPostFormUrlEncodedAsync<ScheduledMessageListRequest, ScheduledMessageListResponse>("scheduledMessages.list", scheduledMessageListRequest);
		
		/// <inheritdoc cref="UpdateAsync(MessageToUpdate)"/>
		public Task<UpdateMessageResponse> UpdateAsync(string channelId, string messageTimestamp, string text = null, List<Attachment> attachments = null, List<BlockBase> blocks = null)
			=> UpdateAsync(new MessageToUpdate(channelId, messageTimestamp, text, attachments, blocks));
		
		/// <summary>
		/// Updates a message.
		/// </summary>
		public Task<UpdateMessageResponse> UpdateAsync(MessageToUpdate messageToUpdate)
			=> SendPostJsonStringAsync<MessageToUpdate, UpdateMessageResponse>("update", messageToUpdate);
	}
}