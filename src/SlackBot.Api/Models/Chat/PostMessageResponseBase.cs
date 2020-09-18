using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Response;

namespace SlackBot.Api.Models.Chat
{
	public class PostMessageResponseBase : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public BotMessageResponse Message { get; set; }
	}
}