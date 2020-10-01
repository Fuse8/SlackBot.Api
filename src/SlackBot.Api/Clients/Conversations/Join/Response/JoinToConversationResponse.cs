using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Join.Response
{
	public class JoinToConversationResponse : ConversationResponse
	{
		[JsonProperty("warning")]
		public string Warning { get; set; }

		[JsonProperty("response_metadata")]
		public WarningResponseMetadata Metadata { get; set; }
	}
}