using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.User;

namespace SlackBot.Api.Models.UserProfile.Get.Response
{
	public class UserProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public UserProfileInfo Profile { get; set; }
	}
}