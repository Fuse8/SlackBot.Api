using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.User;

namespace SlackBot.Api.Models.User
{
	public class UserResponse : SlackBaseResponse
	{
		[JsonProperty("user")]
		public SlackUser User { get; set; }
	}
}