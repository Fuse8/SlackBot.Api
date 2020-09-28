using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.BotInfo;

namespace SlackBot.Api.Models.Bot.Info.Response
{
	public class BotInfoResponse : SlackBaseResponse
	{
		[JsonProperty("bot")]
		public BotInfo Bot { get; set; }
	}
}