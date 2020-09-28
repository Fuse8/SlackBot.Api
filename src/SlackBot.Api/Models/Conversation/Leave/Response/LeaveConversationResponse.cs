using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Conversation.Leave.Response
{
	public class LeaveConversationResponse : SlackBaseResponse
	{
		[JsonProperty("not_in_channel")]
		public bool? NotInChannel { get; set; }
	}
}