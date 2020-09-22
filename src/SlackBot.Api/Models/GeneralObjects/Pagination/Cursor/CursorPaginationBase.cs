using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.GeneralObjects.Pagination.Cursor
{
    public abstract class CursorPaginationBase
    {
        protected CursorPaginationBase()
        {
        }
        
        protected CursorPaginationBase(long? limit, string cursor, string oldest, string latest)
        {
            Cursor = cursor;
            Limit = limit;
            Oldest = oldest;
            Latest = latest;
        }

        /// <summary>
        /// Paginate through collections of data by setting the cursor parameter to a next_cursor attribute returned by a previous request's response_metadata.
        /// Default value fetches the first "page" of the collection.
        /// </summary>
        /// <example>dXNlcjpVMDYxTkZUVDI=</example>
        [FormPropertyName("cursor")]
        public string Cursor { get; set; }
	
        /// <summary>
        /// The maximum number of items to return.
        /// Fewer than the requested number of items may be returned, even if the end of the users list hasn't been reached.
        /// <para><strong>Default: 100</strong></para>
        /// </summary>
        /// <example>20</example>
        [FormPropertyName("limit")]
        public long? Limit { get; set; }

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