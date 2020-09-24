using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;
using SlackBot.Api.Models.GeneralObjects.User;

namespace SlackBot.Api.Models.User.List.Response
{
	public class UserListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public SlackUser[] Members { get; set; }

		[JsonProperty("cache_ts")]
		public long CacheTimestamp { get; set; }
	}
}