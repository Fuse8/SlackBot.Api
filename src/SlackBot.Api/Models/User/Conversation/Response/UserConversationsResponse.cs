using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.User.Conversation.Response
{
	public class UserConversationsResponse : CursorPaginationResponseBase
	{
		[JsonProperty("channels")]
		public Channel[] Channels { get; set; }
	}
}