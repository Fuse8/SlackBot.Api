using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class SendMessageResponse : PostMessageResponseBase
	{
		[JsonProperty("ts")]
		public string Timestamp { get; set; }
	}
}