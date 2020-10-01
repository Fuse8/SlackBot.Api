using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.List.Response
{
	public class UserGroupUserListResponse : SlackBaseResponse
	{
		[JsonProperty("users")]
		public List<string> UserIds { get; set; }
	}
}