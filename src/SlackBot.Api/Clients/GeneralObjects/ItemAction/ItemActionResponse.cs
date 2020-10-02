using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ItemActionResponse
	{
		[JsonProperty("type")]
		public string Type { get; set; }
		
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("message")]
		public MessageObject Message { get; set; }

		[JsonProperty("file")]
		public FileObject File { get; set; }
	}
}