using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Team.Info.Response
{
	public class TeamInfoResponse : SlackBaseResponse
	{
		[JsonProperty("team")]
		public TeamInfo Team { get; set; }
	}
}