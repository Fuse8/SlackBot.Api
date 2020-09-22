using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Chat.ScheduledMessagesList.Response
{
	public class ScheduledMessageListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("scheduled_messages")]
		public ScheduledMessage[] ScheduledMessages { get; set; }
	}
}