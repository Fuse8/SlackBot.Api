using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Response
{
	public class PostMessageResponse : SlackResponseBase
	{
		[JsonProperty("channel")]
		public string Channel { get; set; }

		[JsonProperty("ts")]
		public string ThreadId { get; set; }

		[JsonProperty("message")]
		public BotMessageResponse Message { get; set; }
	}
}