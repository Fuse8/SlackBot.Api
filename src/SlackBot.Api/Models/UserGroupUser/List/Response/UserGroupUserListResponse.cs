using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.UserGroupUser.List.Response
{
	public class UserGroupUserListResponse : SlackBaseResponse
	{
		[JsonProperty("users")]
		public List<string> UserIds { get; set; }
	}
}