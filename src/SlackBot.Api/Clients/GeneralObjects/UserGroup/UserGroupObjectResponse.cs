using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserGroupObjectResponse : SlackBaseResponse
	{
		[JsonProperty("usergroup")]
		public UserGroupObject UserGroup { get; set; }
	}
}