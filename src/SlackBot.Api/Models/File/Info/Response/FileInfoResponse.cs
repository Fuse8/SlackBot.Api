using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.File.Info.Response
{
	public class FileInfoResponse : SlackBaseResponse
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}