using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ReactionsByItemResponse : SlackFileResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public MessageResponse Message { get; set; }
	}
}