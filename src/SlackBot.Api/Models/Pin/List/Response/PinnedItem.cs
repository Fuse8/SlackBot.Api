using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Message;

namespace SlackBot.Api.Models.Pin.List.Response
{
	public class PinnedItem
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("created")]
		public long CreatedTimestamp { get; set; }

		[JsonProperty("created_by")]
		public string CreatedByUserId { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("message")]
		public MessageResponse Message { get; set; }

		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}