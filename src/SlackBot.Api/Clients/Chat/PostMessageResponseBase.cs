using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class PostMessageResponseBase : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public BotMessageResponse Message { get; set; }
	}
}