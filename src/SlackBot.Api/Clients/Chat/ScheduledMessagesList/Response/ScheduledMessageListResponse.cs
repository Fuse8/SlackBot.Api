using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.ScheduledMessagesList.Response
{
	public class ScheduledMessageListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("scheduled_messages")]
		public List<ScheduledMessage> ScheduledMessages { get; set; }
	}
}