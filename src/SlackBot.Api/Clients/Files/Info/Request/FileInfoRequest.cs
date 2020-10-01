using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class FileInfoRequest : CursorPaginationBase
	{
		public FileInfoRequest()
		{
		}

		public FileInfoRequest(string fileId)
		{
			FileId = fileId;
		}

		/// <summary>
		/// Specify a file by providing its ID.
		/// </summary>
		/// <example>F2147483862</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }
		
		/// <summary>
		/// Number of items to return per page.
		/// <para><strong>Default: 100</strong></para>
		/// </summary>
		/// <example>20</example>
		[FormPropertyName("count")]
		public long? Count { get; set; }

		/// <summary>
		/// Page number of results to return.
		/// <para><strong>Default: 1</strong></para>
		/// </summary>
		/// <example>2</example>
		[FormPropertyName("page")]
		public long? Page { get; set; }
	}
}