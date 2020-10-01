using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;
using SlackBot.Api.Clients.GeneralObjects.User;

namespace SlackBot.Api.Clients.List.Response
{
	public class UserListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public List<SlackUser> Members { get; set; }

		[JsonProperty("cache_ts")]
		public long CacheTimestamp { get; set; }
	}
}