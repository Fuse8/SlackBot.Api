using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Chat.PostEphemeral.Response
{
	public class SendEphemeralMessageResponse : SlackBaseResponse
	{
		[JsonProperty("message_ts")]
		public string MessageTimestamp { get; set; }
	}
}