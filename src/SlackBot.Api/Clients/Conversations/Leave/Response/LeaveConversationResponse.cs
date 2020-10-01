using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class LeaveConversationResponse : SlackBaseResponse
	{
		[JsonProperty("not_in_channel")]
		public bool? NotInChannel { get; set; }
	}
}