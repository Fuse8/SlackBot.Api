using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserGroupUserListResponse : SlackBaseResponse
	{
		[JsonProperty("users")]
		public List<string> UserIds { get; set; }
	}
}