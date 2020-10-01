using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class BotInfoResponse : SlackBaseResponse
	{
		[JsonProperty("bot")]
		public BotInfo Bot { get; set; }
	}
}