using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class PinListResponse : SlackBaseResponse
	{
		[JsonProperty("items")]
		public List<PinnedItem> Items { get; set; }
	}
}