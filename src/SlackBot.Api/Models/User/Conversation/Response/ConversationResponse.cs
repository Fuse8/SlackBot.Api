using Newtonsoft.Json;

namespace SlackBot.Api.Models.User.Conversation.Response
{
	public class ConversationResponse : SlackResponseBase
	{
		[JsonProperty("channels")]
		public Channel[] Channels { get; set; }

		[JsonProperty("response_metadata")]
		public CursorPaginationMetadata Metadata { get; set; }
	}
}