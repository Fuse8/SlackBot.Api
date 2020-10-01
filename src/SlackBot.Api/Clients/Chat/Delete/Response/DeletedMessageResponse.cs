using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Delete.Response
{
	public class DeletedMessageResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("ts")]
		public string MessageTimestamp { get; set; }
	}
}