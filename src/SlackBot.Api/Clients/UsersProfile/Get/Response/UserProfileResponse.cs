using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public UserProfileObject Profile { get; set; }
	}
}