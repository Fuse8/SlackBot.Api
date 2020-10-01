using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.List.Response
{
	public class PinnedItem : ItemResponse
	{
		[JsonProperty("created")]
		public long CreatedTimestamp { get; set; }

		[JsonProperty("created_by")]
		public string CreatedByUserId { get; set; }
	}
}