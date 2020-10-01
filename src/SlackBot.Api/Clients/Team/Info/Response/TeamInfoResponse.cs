using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class TeamInfoResponse : SlackBaseResponse
	{
		[JsonProperty("team")]
		public TeamInfo Team { get; set; }
	}
}