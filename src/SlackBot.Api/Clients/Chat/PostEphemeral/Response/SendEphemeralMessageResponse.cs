using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class SendEphemeralMessageResponse : SlackBaseResponse
	{
		[JsonProperty("message_ts")]
		public string MessageTimestamp { get; set; }
	}
}