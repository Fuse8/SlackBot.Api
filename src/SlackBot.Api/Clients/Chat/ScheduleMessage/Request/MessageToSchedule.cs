using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage;

namespace SlackBot.Api.Clients.ScheduleMessage.Request
{
	public class MessageToSchedule : Message
	{
		/// <summary>
		/// Unix EPOCH timestamp of time in future to send the message.
		/// </summary>
		/// <example>299876400</example>
		[JsonProperty("post_at")]
		public long PostAt { get; set; }
	}
}