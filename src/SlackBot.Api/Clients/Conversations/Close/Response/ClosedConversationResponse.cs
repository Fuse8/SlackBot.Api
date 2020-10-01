using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Close.Response
{
	public class ClosedConversationResponse : SlackBaseResponse
	{
		[JsonProperty("no_op")]
		public bool? NoOperation { get; set; }

		[JsonProperty("already_closed")]
		public bool? IsAlreadyClosed { get; set; }
	}
}