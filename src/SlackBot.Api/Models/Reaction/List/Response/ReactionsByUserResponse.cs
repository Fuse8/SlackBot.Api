using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Reaction.List.Response
{
	public class ReactionsByUserResponse : CursorPaginationResponseBase
	{
		[JsonProperty("items")]
		public List<ItemResponse> Items { get; set; }
	}
}