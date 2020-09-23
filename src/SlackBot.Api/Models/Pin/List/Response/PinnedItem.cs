using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Pin.List.Response
{
	public class PinnedItem : ItemResponse
	{
		[JsonProperty("created")]
		public long CreatedTimestamp { get; set; }

		[JsonProperty("created_by")]
		public string CreatedByUserId { get; set; }
	}
}