using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.List.Response
{
	public class ReactionsByUserResponse : CursorPaginationResponseBase
	{
		[JsonProperty("items")]
		public List<ItemResponse> Items { get; set; }
	}
}