using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ConversationMembersResponse : CursorPaginationResponseBase
	{
		[JsonProperty("members")]
		public List<string> MemberIds { get; set; }
	}
}