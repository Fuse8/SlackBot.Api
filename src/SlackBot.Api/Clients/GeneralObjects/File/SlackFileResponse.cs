using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects.File
{
	public class SlackFileResponse : SlackBaseResponse
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }
	}
}