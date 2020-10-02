using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class JoinToConversationResponse : ConversationResponse
	{
		[JsonProperty("warning")]
		public string Warning { get; set; }

		[JsonProperty("response_metadata")]
		public WarningResponseMetadata Metadata { get; set; }
	}
}