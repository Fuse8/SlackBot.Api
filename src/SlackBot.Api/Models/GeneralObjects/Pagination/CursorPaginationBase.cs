using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.GeneralObjects.Pagination
{
    public abstract class CursorPaginationBase
    {
        protected CursorPaginationBase()
        {
        }
        
        protected CursorPaginationBase(long? limit, string cursor = null)
        {
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// Paginate through collections of data by setting the cursor parameter to a next_cursor attribute returned by a previous request's response_metadata.
        /// Default value fetches the first "page" of the collection.
        /// </summary>
        [FormPropertyName("cursor")]
        public string Cursor { get; set; }
	
        /// <summary>
        /// The maximum number of items to return.
        /// Fewer than the requested number of items may be returned, even if the end of the users list hasn't been reached.
        ///
        /// <para><strong>Default: 100</strong></para>
        /// </summary>
        [FormPropertyName("limit")]
        public long? Limit { get; set; }
    }
}