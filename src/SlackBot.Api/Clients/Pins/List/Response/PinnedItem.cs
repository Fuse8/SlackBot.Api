using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class PinnedItem : ItemResponse
	{
		[JsonProperty("created")]
		public long CreatedTimestamp { get; set; }

		[JsonProperty("created_by")]
		public string CreatedByUserId { get; set; }
	}
}