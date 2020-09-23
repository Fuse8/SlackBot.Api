using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Reaction.List.Response
{
	public class GetReactionsByUserResponse : CursorPaginationResponseBase
	{
		[JsonProperty("items")]
		public ItemResponse[] Items { get; set; }
	}
}