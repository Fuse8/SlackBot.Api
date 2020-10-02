using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ConversationResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public ConversationInfo Channel { get; set; }
	}
}