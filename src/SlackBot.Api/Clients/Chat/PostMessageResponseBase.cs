using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class PostMessageResponseBase : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public BotMessageResponse Message { get; set; }
	}
}