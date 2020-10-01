using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.PostMessage.Response;

namespace SlackBot.Api.Clients.Update.Response
{
	public class UpdateMessageResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("ts")]
		public string MessageTimestamp { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("message")]
		public BotMessageResponse Message { get; set; }
	}
}