using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.TeamProfile.Get.Response
{
	public class TeamProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public TeamProfile Profile { get; set; }
	}
}