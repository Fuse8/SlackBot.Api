using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Pagination
{
	public class CursorPaginationMetadata
	{
		[JsonProperty("next_cursor")]
		public string NextCursor { get; set; }
	}
}