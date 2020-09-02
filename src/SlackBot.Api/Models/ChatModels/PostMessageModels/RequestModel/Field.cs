using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel
{
	public class Field
	{
		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("value")]
		public string Value { get; set; }

		[JsonPropertyName("short")]
		public bool Short { get; set; }
	}
}