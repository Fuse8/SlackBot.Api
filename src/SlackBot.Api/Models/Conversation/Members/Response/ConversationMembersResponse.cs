using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Conversation.Members.Response
{
	public class ConversationMembersResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public string[] MemberIds { get; set; }
	}
}