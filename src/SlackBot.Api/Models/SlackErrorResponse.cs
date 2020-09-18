using Newtonsoft.Json;

namespace SlackBot.Api.Models
{
	public class SlackErrorResponse : SlackBaseResponse
	{
		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("warning")]
		public string Warning { get; set; }
	}
}