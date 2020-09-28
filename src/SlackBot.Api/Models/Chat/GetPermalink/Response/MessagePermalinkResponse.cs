using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Chat.GetPermalink.Response
{
	public class MessagePermalinkResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("permalink")]
		public Uri Permalink { get; set; }
	}
}