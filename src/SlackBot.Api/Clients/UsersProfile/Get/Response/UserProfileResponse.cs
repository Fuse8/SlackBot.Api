using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public UserProfileInfo Profile { get; set; }
	}
}