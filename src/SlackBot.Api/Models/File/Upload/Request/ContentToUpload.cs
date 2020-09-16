using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.File.Upload.Request
{
	public class ContentToUpload : FileToUploadBase
	{
		/// <summary>
		/// File contents via a POST variable. If omitting this parameter, you must provide a <see cref="FileToUpload.Stream"/>.
		/// </summary>
		/// <example>Some content</example>
		[FormPropertyName("content")]
		public string Content { get; set; }
	}
}