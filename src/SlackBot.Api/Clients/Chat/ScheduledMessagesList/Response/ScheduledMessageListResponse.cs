using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ScheduledMessageListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("scheduled_messages")]
		public List<ScheduledMessage> ScheduledMessages { get; set; }
	}
}