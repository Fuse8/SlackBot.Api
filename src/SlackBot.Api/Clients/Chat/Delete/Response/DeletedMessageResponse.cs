using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class DeletedMessageResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("ts")]
		public string MessageTimestamp { get; set; }
	}
}