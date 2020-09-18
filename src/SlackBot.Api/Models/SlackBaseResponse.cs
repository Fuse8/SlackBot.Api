using Newtonsoft.Json;

namespace SlackBot.Api.Models
{
	public class SlackBaseResponse
	{
		[JsonProperty("ok")]
		public bool Ok { get; set; }
	}
}