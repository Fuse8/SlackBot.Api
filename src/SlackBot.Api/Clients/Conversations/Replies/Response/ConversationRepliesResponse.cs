using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ConversationRepliesResponse : CursorPaginationResponseBase
	{
		[JsonProperty("messages")]
		public List<MessageObject> Messages { get; set; }

		[JsonProperty("has_more")]
		public bool HasMore { get; set; }
	}
}