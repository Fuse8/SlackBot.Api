using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserGroupResponse : SlackBaseResponse
	{
		[JsonProperty("usergroup")]
		public UserGroupObject UserGroup { get; set; }
	}
}