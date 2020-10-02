using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class FileListRequest : ClassicPaginationRequestBase
	{
		public FileListRequest()
		{
		}

		public FileListRequest(string channelId, string timestampFrom = null, string timestampTo = null, long? count = null, long? page = null)
			: base(count, page)
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
		/// Show truncated file info for files hidden due to being too old, and the team who owns the file being over the file limit.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("show_files_hidden_by_limit")]
		public bool? ShowFilesHiddenByLimit { get; set; }

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

		/// <summary>
		/// Filter files by type. You can pass multiple values in the types argument, like types="spaces,snippets".
		/// The default value is "all", which does not filter the list. List of file types:
		/// <list>
		/// <item> <term>all</term> <description>All files</description> </item>
		/// <item> <term>spaces</term> <description>Posts</description> </item>
		/// <item> <term>snippets</term> <description>Snippets</description> </item>
		/// <item> <term>images</term> <description>Image files</description> </item>
		/// <item> <term>gdocs</term> <description>Google docs</description> </item>
		/// <item> <term>zips</term> <description>Zip files</description> </item>
		/// <item> <term>pdfs</term> <description>PDF files</description> </item>
		/// </list> 
		/// <para><strong>Default: all</strong></para>
		/// </summary>
		/// <example>images</example>
		[FormPropertyName("types")]
		public string Types { get; set; }

		/// <summary>
		/// Filter files created by a single user.
		/// </summary>
		/// <example>W1234567890</example>
		[FormPropertyName("user")]
		public string UserId { get; set; }
	}
}