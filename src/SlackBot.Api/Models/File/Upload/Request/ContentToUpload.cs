using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.File.Upload.Request
{
	public class ContentToUpload : FileToUploadBase
	{
		[FormPropertyName("content")]
		public string Content { get; set; }
	}
}