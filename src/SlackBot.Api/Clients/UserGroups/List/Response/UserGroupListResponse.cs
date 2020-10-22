using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserGroupListResponse : SlackBaseResponse
	{
		[JsonProperty("usergroups")]
		public List<UserGroupObject> UserGroups { get; set; }
	}
}