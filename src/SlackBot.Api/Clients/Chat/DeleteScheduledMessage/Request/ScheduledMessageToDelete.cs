using Newtonsoft.Json;
using SlackBot.Api.Clients.ScheduleMessage.Response;

namespace SlackBot.Api.Clients.DeleteScheduledMessage.Request
{
	public class ScheduledMessageToDelete
	{
		public ScheduledMessageToDelete()
		{
		}

		public ScheduledMessageToDelete(string channel, string scheduledMessageId)
		{
			Channel = channel;
			ScheduledMessageId = scheduledMessageId;
		}

		/// <summary>
		/// The channel the scheduled_message is posting to
		/// </summary>
		/// <example>C123456789</example>
		[JsonProperty("channel")]
		public string Channel { get; set; }
		
		/// <summary>
		/// <see cref="ScheduleMessageResponse.ScheduledMessageId"/> returned from call to "chat.scheduleMessage"
		/// </summary>
		/// <example>Q12345678</example>
		[JsonProperty("scheduled_message_id")]
		public string ScheduledMessageId { get; set; }

		/// <summary>
		/// Pass "true" to delete the message as the authed user with "chat:write:user" scope.
		/// Bot users in this context are considered authed users. If unused or "false", the message will be deleted with "chat:write:bot" scope.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[JsonProperty("as_user")]
		public bool? AsUser { get; set; }
	}
}