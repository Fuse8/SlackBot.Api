using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.GetPermalink.Response
{
	public class GetPermalinkResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("permalink")]
		public Uri Permalink { get; set; }
	}
}