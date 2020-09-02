using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class Purpose
	{
		[JsonPropertyName("value")]
		public string Value { get; set; }

		[JsonPropertyName("creator")]
		public string Creator { get; set; }

		[JsonPropertyName("last_set")]
		public long LastSet { get; set; }
	}
}