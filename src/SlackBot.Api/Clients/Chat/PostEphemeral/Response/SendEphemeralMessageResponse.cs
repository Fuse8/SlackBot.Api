using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.PostEphemeral.Response
{
	public class SendEphemeralMessageResponse : SlackBaseResponse
	{
		[JsonProperty("message_ts")]
		public string MessageTimestamp { get; set; }
	}
}