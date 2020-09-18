using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage;

namespace SlackBot.Api.Models.Chat.ScheduleMessage.Request
{
	public class ScheduledMessage : Message
	{
		/// <summary>
		/// Unix EPOCH timestamp of time in future to send the message.
		/// </summary>
		/// <example>299876400</example>
		[JsonProperty("post_at")]
		public long PostAt { get; set; }
	}
}