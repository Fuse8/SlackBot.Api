using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.UserGroup;

namespace SlackBot.Api.Models.UserGroup.List.Response
{
	public class UserGroupListResponse : SlackBaseResponse
	{
		[JsonProperty("usergroups")]
		public List<UserGroupResponse> UserGroups { get; set; }
	}
}