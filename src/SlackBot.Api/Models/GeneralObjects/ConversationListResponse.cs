using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Conversation;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.GeneralObjects
{
	public class ConversationListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("channels")]
		public ConversationInfo[] Channels { get; set; }
	}
}