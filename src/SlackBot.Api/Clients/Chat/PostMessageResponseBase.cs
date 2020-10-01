using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.PostMessage.Response;

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