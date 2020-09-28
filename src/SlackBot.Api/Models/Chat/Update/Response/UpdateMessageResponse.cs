using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Chat.Update.Response
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