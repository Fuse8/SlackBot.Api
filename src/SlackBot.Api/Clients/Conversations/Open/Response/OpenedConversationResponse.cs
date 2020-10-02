using Newtonsoft.Json;

namespace SlackBot.Api
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