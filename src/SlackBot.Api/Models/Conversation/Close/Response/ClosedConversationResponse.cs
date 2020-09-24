using Newtonsoft.Json;

namespace SlackBot.Api.Models.Conversation.Close.Response
{
	public class ClosedConversationResponse : SlackBaseResponse
	{
		[JsonProperty("no_op")]
		public bool? NoOperation { get; set; }

		[JsonProperty("already_closed")]
		public bool? IsAlreadyClosed { get; set; }
	}
}