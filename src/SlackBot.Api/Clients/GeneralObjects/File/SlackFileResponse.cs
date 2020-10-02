using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class SlackFileResponse : SlackBaseResponse
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}