using System.Text.Json.Serialization;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class UploadFileResponse : SlackResponseBase
	{
		[JsonPropertyName("file")]
		public SlackFile File { get; set; }
	}
}