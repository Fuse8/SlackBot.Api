using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Info.Response
{
	public class TeamInfoResponse : SlackBaseResponse
	{
		[JsonProperty("team")]
		public TeamInfo Team { get; set; }
	}
}