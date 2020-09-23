using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.User;

namespace SlackBot.Api.Models.User.Info.Response
{
	public class UserInfoResponse : SlackBaseResponse
	{
		[JsonProperty("user")]
		public SlackUser User { get; set; }
	}
}