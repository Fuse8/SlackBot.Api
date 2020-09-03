using Newtonsoft.Json;

namespace SlackBot.Api.Models.UserModels.ConversationModels.ResponseModels
{
	public class ConversationResponse : SlackResponseBase
	{
		[JsonProperty("channels")]
		public Channel[] Channels { get; set; }

		[JsonProperty("response_metadata")]
		public CursorPaginationMetadata Metadata { get; set; }
	}
}