using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.Delete.Response
{
	public class DeletedMessageResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("ts")]
		public string MessageTimestamp { get; set; }
	}
}