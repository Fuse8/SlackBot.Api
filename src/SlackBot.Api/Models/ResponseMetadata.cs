using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class ResponseMetadata
	{		
		[JsonPropertyName("next_cursor")]
		public string NextCursor { get; set; }
	}
}