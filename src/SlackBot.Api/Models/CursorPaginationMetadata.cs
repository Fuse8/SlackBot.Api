using Newtonsoft.Json;

namespace SlackBot.Api.Models
{
	public class CursorPaginationMetadata
	{		
		[JsonProperty("next_cursor")]
		public string NextCursor { get; set; }
	}
}