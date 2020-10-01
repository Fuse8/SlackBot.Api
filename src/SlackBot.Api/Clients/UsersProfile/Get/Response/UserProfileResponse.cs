using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class UserProfileResponse : SlackBaseResponse
	{
		[JsonProperty("profile")]
		public UserProfileInfo Profile { get; set; }
	}
}