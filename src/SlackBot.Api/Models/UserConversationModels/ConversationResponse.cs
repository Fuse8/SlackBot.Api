using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.UserConversationModels
{
	public class ConversationResponse : SlackResponseBase
	{
		[JsonPropertyName("channels")]
		public Channel[] Channels { get; set; }

		[JsonPropertyName("response_metadata")]
		public ResponseMetadata Metadata { get; set; }
	}
}