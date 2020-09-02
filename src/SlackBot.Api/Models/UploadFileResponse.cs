using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class UploadFileResponse : SlackResponseBase
	{
		[JsonPropertyName("file")]
		public SlackFile File { get; set; }
	}
}