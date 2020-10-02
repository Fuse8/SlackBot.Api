using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class SendMessageResponse : PostMessageResponseBase
	{
		[JsonProperty("ts")]
		public string Timestamp { get; set; }
	}
}