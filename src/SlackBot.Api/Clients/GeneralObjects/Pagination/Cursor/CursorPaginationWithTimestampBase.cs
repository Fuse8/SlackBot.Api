using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
    public abstract class CursorPaginationWithTimestampBase : CursorPaginationBase
    {
        protected CursorPaginationWithTimestampBase()
        {
        }
        
        protected CursorPaginationWithTimestampBase(string cursor, long? limit, string oldest, string latest)
            : base(cursor, limit)
        {
            Oldest = oldest;
            Latest = latest;
        }

        /// <summary>
        /// A UNIX timestamp of the latest value in the time range.
        /// <para><strong>Default: now</strong></para>
        /// </summary>
        /// <example>1234567890.123456</example>
        [FormPropertyName("latest")]
        public string Latest { get; set; }
		
        /// <summary>
        /// A UNIX timestamp of the oldest value in the time range
        /// <para><strong>Default: 0</strong></para>
        /// </summary>
        /// <example>1234567890.123456</example>
        [FormPropertyName("oldest")]
        public string Oldest { get; set; }
    }
}