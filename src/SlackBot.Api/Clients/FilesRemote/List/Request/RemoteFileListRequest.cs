using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class RemoteFileListRequest : CursorPaginationBase
	{
		public RemoteFileListRequest()
		{
		}

		public RemoteFileListRequest(string channelId, string timestampFrom = null, string timestampTo = null, string cursor = null, long? limit = null)
			: base(cursor, limit)
		{
			ChannelId = channelId;
			TimestampFrom = timestampFrom;
			TimestampTo = timestampTo;
		}
		
		/// <summary>
		/// Filter files appearing in a specific channel, indicated by its ID.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Filter files created after this timestamp (inclusive).
		/// <para><strong>Default: 0</strong></para>
		/// </summary>
		/// <example>123456789</example>
		[FormPropertyName("ts_from")]
		public string TimestampFrom { get; set; }

		/// <summary>
		/// Filter files created before this timestamp (inclusive).
		/// <para><strong>Default: now</strong></para>
		/// </summary>
		/// <example>123456789</example>
		[FormPropertyName("ts_to")]
		public string TimestampTo { get; set; }
	}
}