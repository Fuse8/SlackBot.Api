using Newtonsoft.Json;

namespace SlackBot.Api.Models.TeamProfile.Get.Response
{
	public class TeamProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public TeamProfile Profile { get; set; }
	}
}