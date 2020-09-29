using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.UserGroup
{
	public class UserGroupResponse : SlackBaseResponse
	{
		[JsonProperty("usergroup")]
		public UserGroupObject UserGroup { get; set; }
	}
}