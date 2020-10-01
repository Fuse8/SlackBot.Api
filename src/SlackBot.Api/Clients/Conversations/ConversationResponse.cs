using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GeneralObjects.Conversation;

namespace SlackBot.Api.Clients
{
	public class ConversationResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public ConversationInfo Channel { get; set; }
	}
}