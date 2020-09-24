using Newtonsoft.Json;

namespace SlackBot.Api.Models.TeamProfile.Get.Response
{
	public class TeamProfile
	{
		[JsonProperty("fields")]
		public TeamField[] Fields { get; set; }
	}
}