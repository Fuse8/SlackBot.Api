using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ScheduledMessageToDelete
	{
		public ScheduledMessageToDelete()
		{
		}

		public ScheduledMessageToDelete(string channelId, string scheduledMessageId)
		{
			ChannelId = channelId;
			ScheduledMessageId = scheduledMessageId;
		}

		/// <summary>
		/// The channel the scheduled_message is posting to
		/// </summary>
		/// <example>C123456789</example>
		[JsonProperty("channel")]
		public string ChannelId { get; set; }
		
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