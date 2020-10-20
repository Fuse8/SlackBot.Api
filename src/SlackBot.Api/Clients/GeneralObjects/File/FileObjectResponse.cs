using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class FileObjectResponse : SlackBaseResponse
	{
		[JsonProperty("file")]
		public FileObject File { get; set; }
	}
}