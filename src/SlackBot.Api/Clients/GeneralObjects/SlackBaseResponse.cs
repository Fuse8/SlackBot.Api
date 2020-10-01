using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects
{
	public class SlackBaseResponse
	{
		[JsonProperty("ok")]
		public bool Ok { get; set; }
	}
}