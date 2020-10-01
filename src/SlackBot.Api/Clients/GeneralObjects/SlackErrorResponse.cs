using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class SlackErrorResponse : SlackBaseResponse
	{
		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("warning")]
		public string Warning { get; set; }

		[JsonProperty("response_metadata")]
		public object Metadata { get; set; }

		[JsonProperty("errors")]
		public object Errors { get; set; }
	}
}