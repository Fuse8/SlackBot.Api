using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.UserGroup;

namespace SlackBot.Api.Models.UserGroup
{
	public class UserGroupActionResponse : SlackBaseResponse
	{
		[JsonProperty("usergroup")]
		public UserGroupResponse UserGroup { get; set; }
	}
}