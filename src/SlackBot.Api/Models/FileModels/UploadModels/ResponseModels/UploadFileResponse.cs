using Newtonsoft.Json;

namespace SlackBot.Api.Models.FileModels.UploadModels.ResponseModels
{
	public class UploadFileResponse : SlackResponseBase
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}