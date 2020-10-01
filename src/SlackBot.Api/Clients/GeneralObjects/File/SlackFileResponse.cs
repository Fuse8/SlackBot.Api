using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class SlackFileResponse : SlackBaseResponse
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}