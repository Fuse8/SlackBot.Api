using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GeneralObjects.User;

namespace SlackBot.Api.Clients.Get.Response
{
	public class UserProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public UserProfileInfo Profile { get; set; }
	}
}