using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class TeamProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public TeamProfile Profile { get; set; }
	}
}