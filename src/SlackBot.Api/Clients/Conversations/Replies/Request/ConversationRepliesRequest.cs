using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ConversationRepliesRequest : CursorPaginationWithTimestampRequestBase
	{
		public ConversationRepliesRequest()
		{
		}

		public ConversationRepliesRequest(string channelId, string messageTimestamp, string cursor = null, long? limit = null, string oldest = null, string latest = null)
			: base(cursor, limit, oldest, latest)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
		}

		/// <summary>
		/// Conversation ID to fetch thread from.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Unique identifier of a thread's parent message. <see cref="MessageTimestamp"/> must be the timestamp of an existing message with 0 or more replies.
		/// If there are no replies then just the single message referenced by <see cref="MessageTimestamp"/> will return - it is just an ordinary, unthreaded message.
		/// </summary>
		[FormPropertyName("ts")]
		public string MessageTimestamp { get; set; }

		/// <summary>
		/// Include messages with latest or oldest timestamp in results only when either timestamp is specified.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("inclusive")]
		public bool? Inclusive { get; set; }
	}
}