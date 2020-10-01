using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Leave.Response
{
	public class LeaveConversationResponse : SlackBaseResponse
	{
		[JsonProperty("not_in_channel")]
		public bool? NotInChannel { get; set; }
	}
}