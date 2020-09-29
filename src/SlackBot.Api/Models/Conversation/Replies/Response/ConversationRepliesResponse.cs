using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Message;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Conversation.Replies.Response
{
	public class ConversationRepliesResponse : CursorPaginationResponseBase
	{
		[JsonProperty("messages")]
		public List<MessageResponse> Messages { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
	}
}