using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Pin.List.Response
{
	public class PinListResponse : SlackBaseResponse
	{
		[JsonProperty("items")]
		public List<PinnedItem> Items { get; set; }
	}
}