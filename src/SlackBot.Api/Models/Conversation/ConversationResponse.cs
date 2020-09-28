using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Conversation;

namespace SlackBot.Api.Models.Conversation
{
	public class ConversationResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public ConversationInfo Channel { get; set; }
	}
}