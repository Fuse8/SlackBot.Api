using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ConversationRepliesResponse : CursorPaginationResponseBase
	{
		[JsonProperty("messages")]
		public List<MessageResponse> Messages { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
	}
}