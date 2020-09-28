using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Pin.List.Response
{
	public class PinListResponse : SlackBaseResponse
	{
		[JsonProperty("items")]
		public PinnedItem[] Items { get; set; }
	}
}