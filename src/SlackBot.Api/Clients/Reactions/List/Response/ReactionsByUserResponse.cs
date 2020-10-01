using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ReactionsByUserResponse : CursorPaginationResponseBase
	{
		[JsonProperty("items")]
		public List<ItemResponse> Items { get; set; }
	}
}