using Newtonsoft.Json;

namespace SlackBot.Api.Clients.PostMessage.Response
{
	public class SendMessageResponse : PostMessageResponseBase
	{
		[JsonProperty("ts")]
		public string Timestamp { get; set; }
	}
}