using SlackBot.Api.Attributes;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.ScheduledMessagesList.Request
{
	public class ScheduledMessageListRequest : CursorPaginationWithTimestampBase
	{
		public ScheduledMessageListRequest()
		{
		}

		public ScheduledMessageListRequest(string channelId)
		{
			ChannelId = channelId;
		}

		/// <summary>
		/// The channel of the scheduled messages
		/// </summary>
		/// <example>C123456789</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }
	}
}