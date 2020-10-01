using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects.UserGroup
{
	public class UserGroupResponse : SlackBaseResponse
	{
		[JsonProperty("usergroup")]
		public UserGroupObject UserGroup { get; set; }
	}
}