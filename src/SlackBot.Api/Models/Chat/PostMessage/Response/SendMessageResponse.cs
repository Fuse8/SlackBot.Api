using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Response
{
	public class SendMessageResponse : PostMessageResponseBase
	{
		[JsonProperty("ts")]
		public string Timestamp { get; set; }
	}
}