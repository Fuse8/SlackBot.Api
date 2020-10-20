using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class SlackBaseResponse
	{
		[JsonProperty("ok")]
		public bool Ok { get; set; }
	}
}