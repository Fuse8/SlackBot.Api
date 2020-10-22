using System.IO;
using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class FileToUpload : FileToUploadBase
	{
		public FileToUpload()
		{
		}

		public FileToUpload(
			Stream stream,
			string channelNamesOrIds = null,
			string filename = null,
			string comment = null,
			string title = null,
			string fileType = null,
			string threadTimestamp = null)
			: base(channelNamesOrIds, filename, comment, title, fileType, threadTimestamp)
		{
			Stream = stream;
		}
		/// <summary>
		/// File contents via multipart/form-data. If omitting this parameter, you must submit <see cref="ContentToUpload.Content"/>.
		/// </summary>
		[FormPropertyName("file")]
		public Stream Stream { get; set; }
	}
}