using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class UserGroupResponse : SlackBaseResponse
	{
		[JsonProperty("usergroup")]
		public UserGroupObject UserGroup { get; set; }
	}
}