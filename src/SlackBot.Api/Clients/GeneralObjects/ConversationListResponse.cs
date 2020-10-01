using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.Conversation;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.GeneralObjects
{
	public class ConversationListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("channels")]
		public List<ConversationInfo> Channels { get; set; }
	}
}