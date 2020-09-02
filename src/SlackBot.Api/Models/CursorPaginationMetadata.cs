using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class CursorPaginationMetadata
	{		
		[JsonPropertyName("next_cursor")]
		public string NextCursor { get; set; }
	}
}