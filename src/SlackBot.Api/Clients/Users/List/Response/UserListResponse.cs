using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class UserListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public List<SlackUser> Members { get; set; }

		[JsonProperty("cache_ts")]
		public long CacheTimestamp { get; set; }
	}
}