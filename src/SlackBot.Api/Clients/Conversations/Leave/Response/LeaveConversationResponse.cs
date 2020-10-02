using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class LeaveConversationResponse : SlackBaseResponse
	{
		[JsonProperty("not_in_channel")]
		public bool? NotInChannel { get; set; }
	}
}