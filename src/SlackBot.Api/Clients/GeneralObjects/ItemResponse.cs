using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ItemResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public MessageResponse Message { get; set; }

		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}