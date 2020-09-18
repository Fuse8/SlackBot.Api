using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class UploadFileResponse : SlackBaseResponse
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}