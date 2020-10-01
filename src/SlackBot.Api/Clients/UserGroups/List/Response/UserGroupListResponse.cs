using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GeneralObjects.UserGroup;

namespace SlackBot.Api.Clients.List.Response
{
	public class UserGroupListResponse : SlackBaseResponse
	{
		[JsonProperty("usergroups")]
		public List<UserGroupObject> UserGroups { get; set; }
	}
}