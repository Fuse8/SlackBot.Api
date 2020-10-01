using System;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.GetPermalink.Response
{
	public class MessagePermalinkResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("permalink")]
		public Uri Permalink { get; set; }
	}
}