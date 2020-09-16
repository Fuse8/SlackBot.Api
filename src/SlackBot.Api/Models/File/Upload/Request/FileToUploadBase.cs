using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.File.Upload.Request
{
	public abstract class FileToUploadBase
	{
		[FormPropertyName("channels")]
		public string Channels { get; set; }

		[FormPropertyName("filename")]
		public string Filename { get; set; }

		[FormPropertyName("filetype")]
		public string FileType { get; set; }

		[FormPropertyName("initial_comment")]
		public string Comment { get; set; }

		[FormPropertyName("title")]
		public string Title { get; set; }

		[FormPropertyName("thread_ts")]
		public string ThreadId { get; set; }
	}
}