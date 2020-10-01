using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.Members.Response
{
	public class ConversationMembersResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public List<string> MemberIds { get; set; }
	}
}