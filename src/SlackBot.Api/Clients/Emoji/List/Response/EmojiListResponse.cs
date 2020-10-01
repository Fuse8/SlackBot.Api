using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.List.Response
{
	public class EmojiListResponse : SlackBaseResponse
	{
		[JsonProperty("emoji")]
		public Dictionary<string, string> EmojiList { get; set; }

		[JsonProperty("cache_ts")]
		public string CacheTimestamp { get; set; }
	}
}