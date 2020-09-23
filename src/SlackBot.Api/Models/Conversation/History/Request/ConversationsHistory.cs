using SlackBot.Api.Attributes;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Conversation.History.Request
{
    public class ConversationsHistory : CursorPaginationWithTimestampBase
    {
        public ConversationsHistory()
        {
        }
        
        public ConversationsHistory(string channelId, long? limit = null, string cursor = null)
            : this(channelId, null, null, null, cursor, limit)
        {
        }

        public ConversationsHistory(string channelId, string latest, bool? inclusive = true, long? limit = 1)
            : this(channelId, inclusive, latest, null, null, limit)
        {
        }

        protected ConversationsHistory(string channelId, bool? inclusive, string latest, string oldest, string cursor, long? limit)
            : base(cursor, limit, oldest, latest)
        {
            ChannelId = channelId;
            Inclusive = inclusive;
        }

        /// <summary>
        /// Conversation ID to fetch history for.
        /// </summary>
        /// <example>C1234567890</example>
        [FormPropertyName("channel")]
        public string ChannelId { get; set; }

        /// <summary>
        /// Include messages with latest or oldest timestamp in results only when either timestamp is specified.
        /// <para><strong>Default: false</strong></para>
        /// </summary>
        /// <example>true</example>
        [FormPropertyName("inclusive")]
        public bool? Inclusive { get; set; }
    }
}