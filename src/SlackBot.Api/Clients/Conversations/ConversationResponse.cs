using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ConversationResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public ConversationObject Channel { get; set; }
	}
}