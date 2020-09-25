using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Conversation.Join.Response
{
	public class JoinToConversationResponse : ConversationResponse
	{
		[JsonProperty("warning")]
		public string Warning { get; set; }

		[JsonProperty("response_metadata")]
		public WarningResponseMetadata Metadata { get; set; }
	}
}