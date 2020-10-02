using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class ContentToUpload : FileToUploadBase
	{
		public ContentToUpload()
		{
		}

		public ContentToUpload(
			string content,
			string channelNamesOrIds = null,
			string filename = null,
			string comment = null,
			string title = null,
			string fileType = null,
			string threadTimestamp = null)
			: base(channelNamesOrIds, filename, comment, title, fileType, threadTimestamp)
		{
			Content = content;
		}

		/// <summary>
		/// File contents via a POST variable. If omitting this parameter, you must provide a <see cref="FileToUpload.Stream"/>.
		/// </summary>
		/// <example>Some content</example>
		[FormPropertyName("content")]
		public string Content { get; set; }
	}
}