using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ConversationResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public ConversationInfo Channel { get; set; }
	}
}