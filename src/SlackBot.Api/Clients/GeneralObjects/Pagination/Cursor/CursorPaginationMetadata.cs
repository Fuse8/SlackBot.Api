using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class CursorPaginationMetadata
	{
		[JsonProperty("next_cursor")]
		public string NextCursor { get; set; }
	}
}