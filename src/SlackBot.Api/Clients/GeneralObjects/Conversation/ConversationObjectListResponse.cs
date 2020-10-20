using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ConversationObjectListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("channels")]
		public List<ConversationObject> Channels { get; set; }
	}
}