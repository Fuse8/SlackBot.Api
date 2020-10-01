using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GeneralObjects.User;

namespace SlackBot.Api.Clients
{
	public class UserResponse : SlackBaseResponse
	{
		[JsonProperty("user")]
		public SlackUser User { get; set; }
	}
}