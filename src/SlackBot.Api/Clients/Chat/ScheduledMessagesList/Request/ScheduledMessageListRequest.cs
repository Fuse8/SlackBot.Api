using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ScheduledMessageListRequest : CursorPaginationWithTimestampRequestBase
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