using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.User.Conversation.Response
{
	public class ConversationResponse : SlackBaseResponse
	{
		[JsonProperty("channels")]
		public Channel[] Channels { get; set; }

		[JsonProperty("response_metadata")]
		public CursorPaginationMetadata Metadata { get; set; }
	}
}