using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Conversation;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.User.Conversation.Response
{
	public class UserConversationsResponse : CursorPaginationResponseBase
	{
		[JsonProperty("channels")]
		public ConversationInfo[] Channels { get; set; }
	}
}