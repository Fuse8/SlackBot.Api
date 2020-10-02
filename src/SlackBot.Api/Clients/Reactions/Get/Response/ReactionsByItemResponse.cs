using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ReactionsByItemResponse : FileObjectResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public MessageObject Message { get; set; }
	}
}