using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.Message;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.Replies.Response
{
	public class ConversationRepliesResponse : CursorPaginationResponseBase
	{
		[JsonProperty("messages")]
		public List<MessageResponse> Messages { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
	}
}