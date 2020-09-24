using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Conversation;

namespace SlackBot.Api.Models.Conversation.Open.Response
{
	public class OpenedConversationResponse : SlackBaseResponse
	{
		[JsonProperty("no_op")]
		public bool? NoOperation { get; set; }

		[JsonProperty("already_open")]
		public bool? IsAlreadyOpened { get; set; }
		
		[JsonProperty("channel")]
		public ConversationInfo Channel { get; set; }
	}
}