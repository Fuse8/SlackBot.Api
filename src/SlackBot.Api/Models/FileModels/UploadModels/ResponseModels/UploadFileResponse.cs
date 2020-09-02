using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.FileModels.UploadModels.ResponseModels
{
	public class UploadFileResponse : SlackResponseBase
	{
		[JsonPropertyName("file")]
		public SlackFile File { get; set; }
	}
}