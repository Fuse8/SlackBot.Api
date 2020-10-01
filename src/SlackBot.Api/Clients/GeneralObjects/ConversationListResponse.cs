using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ConversationListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("channels")]
		public List<ConversationInfo> Channels { get; set; }
	}
}