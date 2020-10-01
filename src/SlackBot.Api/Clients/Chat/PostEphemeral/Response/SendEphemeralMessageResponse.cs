using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class SendEphemeralMessageResponse : SlackBaseResponse
	{
		[JsonProperty("message_ts")]
		public string MessageTimestamp { get; set; }
	}
}