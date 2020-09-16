using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.BotInfo;

namespace SlackBot.Api.Models.Chat.PostMessage.Response
{
	public class BotMessageResponse : Message
	{
		[JsonProperty("bot_id")]
		public string BotId { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("user")]
		public string User { get; set; }

		[JsonProperty("team")]
		public string Team { get; set; }

		[JsonProperty("bot_profile")]
		public BotInfo BotProfile { get; set; }
	}
}