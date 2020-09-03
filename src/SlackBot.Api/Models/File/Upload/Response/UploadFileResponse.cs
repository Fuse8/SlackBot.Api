using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class UploadFileResponse : SlackResponseBase
	{
		[JsonPropertyName("file")]
		public SlackFile File { get; set; }
	}
}