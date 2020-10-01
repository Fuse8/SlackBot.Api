using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class SlackBaseResponse
	{
		[JsonProperty("ok")]
		public bool Ok { get; set; }
	}
}