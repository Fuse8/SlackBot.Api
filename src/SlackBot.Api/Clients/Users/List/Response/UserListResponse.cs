using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public List<UserObject> Members { get; set; }

		[JsonProperty("cache_ts")]
		public long CacheTimestamp { get; set; }
	}
}