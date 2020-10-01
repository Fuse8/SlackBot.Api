using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Get.Response
{
	public class TeamProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public TeamProfile Profile { get; set; }
	}
}