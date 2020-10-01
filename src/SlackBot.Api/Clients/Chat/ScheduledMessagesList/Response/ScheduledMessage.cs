using Newtonsoft.Json;

namespace SlackBot.Api.Clients.ScheduledMessagesList.Response
{
	public class ScheduledMessage
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("channel_id")]
		public string ChannelId { get; set; }

		[JsonProperty("post_at")]
		public long PostAtTimestamp { get; set; }

		[JsonProperty("date_created")]
		public long DateCreatedTimestamp { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}