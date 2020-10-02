using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
    public abstract class CursorPaginationRequestBase
    {
        protected CursorPaginationRequestBase()
        {
        }
        
        protected CursorPaginationRequestBase(string cursor, long? limit)
        {
            Cursor = cursor;
            Limit = limit;
        }
		
        /// <summary>
        /// Parameter for pagination. File comments are paginated for a single file.
        /// Set <see cref="Cursor"/> equal to the <see cref="CursorPaginationMetadata.NextCursor"/> attribute returned by the previous request's <see cref="CursorPaginationMetadata"/>.
        /// This parameter is optional, but pagination is mandatory: the default value simply fetches the first "page" of the collection of comments.
        /// See pagination for more details.
        /// </summary>
        /// <example>dXNlcjpVMDYxTkZUVDI=</example>
        [FormPropertyName("cursor")]
        public string Cursor { get; set; }
	
        /// <summary>
        /// The maximum number of items to return. Fewer than the requested number of items may be returned, even if the end of the list hasn't been reached.
        /// <para><strong>Default: 0</strong></para>
        /// </summary>
        /// <example>20</example>
        [FormPropertyName("limit")]
        public long? Limit { get; set; }
    }
}