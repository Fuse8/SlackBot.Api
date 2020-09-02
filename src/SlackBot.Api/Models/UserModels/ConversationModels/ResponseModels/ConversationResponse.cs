using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.UserModels.ConversationModels.ResponseModels
{
	public class ConversationResponse : SlackResponseBase
	{
		[JsonPropertyName("channels")]
		public Channel[] Channels { get; set; }

		[JsonPropertyName("response_metadata")]
		public CursorPaginationMetadata Metadata { get; set; }
	}
}