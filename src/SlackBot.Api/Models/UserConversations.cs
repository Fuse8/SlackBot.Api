using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class UserConversations
	{
		[JsonPropertyName("cursor")]
		public string Cursor { get; set; }

		[JsonPropertyName("exclude_archived")]
		public bool ExcludeArchived { get; set; }
	
		[JsonPropertyName("limit")]
		public int? Limit { get; set; }
		
		[JsonPropertyName("types")]
		public string Types { get; set; }
		
		[JsonPropertyName("user")]
		public string User { get; set; }
	}
}