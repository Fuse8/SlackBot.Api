using Newtonsoft.Json;

namespace SlackBot.Api.Models.Pin.List.Response
{
	public class PinListResponse : SlackBaseResponse
	{
		[JsonProperty("items")]
		public PinnedItem[] Items { get; set; }
	}
}