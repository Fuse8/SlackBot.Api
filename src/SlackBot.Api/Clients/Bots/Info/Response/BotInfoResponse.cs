using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GeneralObjects.BotInfo;

namespace SlackBot.Api.Clients
{
	public class BotInfoResponse : SlackBaseResponse
	{
		[JsonProperty("bot")]
		public BotInfo Bot { get; set; }
	}
}