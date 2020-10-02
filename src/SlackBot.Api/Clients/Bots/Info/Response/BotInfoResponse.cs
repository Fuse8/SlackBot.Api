using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class BotInfoResponse : SlackBaseResponse
	{
		[JsonProperty("bot")]
		public BotObject Bot { get; set; }
	}
}