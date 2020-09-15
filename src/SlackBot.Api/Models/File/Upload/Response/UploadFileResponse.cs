using Newtonsoft.Json;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class UploadFileResponse : SlackResponseBase
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}