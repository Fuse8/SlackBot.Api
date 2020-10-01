using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.List.Response
{
	public class PinListResponse : SlackBaseResponse
	{
		[JsonProperty("items")]
		public List<PinnedItem> Items { get; set; }
	}
}