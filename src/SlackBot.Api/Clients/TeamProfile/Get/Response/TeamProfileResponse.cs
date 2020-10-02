using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class TeamProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public TeamProfile Profile { get; set; }
	}
}