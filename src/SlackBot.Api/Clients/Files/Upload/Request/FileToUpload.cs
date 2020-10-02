using System.IO;
using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class FileToUpload : FileToUploadBase
	{
		/// <summary>
		/// File contents via multipart/form-data. If omitting this parameter, you must submit <see cref="ContentToUpload.Content"/>.
		/// </summary>
		[FormPropertyName("file")]
		public Stream Stream { get; set; }
	}
}