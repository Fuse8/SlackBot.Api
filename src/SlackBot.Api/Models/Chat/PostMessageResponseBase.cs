using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Response;

namespace SlackBot.Api.Models.Chat
{
	public class PostMessageResponseBase : SlackResponseBase
	{
		[JsonProperty("channel")]
		public string Channel { get; set; }

		[JsonProperty("message")]
		public BotMessageResponse Message { get; set; }
	}
}