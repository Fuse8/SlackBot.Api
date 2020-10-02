using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class BotInfoResponse : SlackBaseResponse
	{
		[JsonProperty("bot")]
		public BotInfo Bot { get; set; }
	}
}