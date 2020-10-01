using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor
{
	public class CursorPaginationMetadata
	{
		[JsonProperty("next_cursor")]
		public string NextCursor { get; set; }
	}
}