using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class TeamInfoResponse : SlackBaseResponse
	{
		[JsonProperty("team")]
		public TeamInfo Team { get; set; }
	}
}