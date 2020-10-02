using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserResponse : SlackBaseResponse
	{
		[JsonProperty("user")]
		public SlackUser User { get; set; }
	}
}