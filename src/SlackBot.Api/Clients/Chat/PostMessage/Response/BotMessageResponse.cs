using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class BotMessageResponse : SlackMessage
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
		public BotObject BotProfile { get; set; }
	}
}