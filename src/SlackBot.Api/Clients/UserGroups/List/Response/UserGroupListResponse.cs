using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class UserGroupListResponse : SlackBaseResponse
	{
		[JsonProperty("usergroups")]
		public List<UserGroupObject> UserGroups { get; set; }
	}
}