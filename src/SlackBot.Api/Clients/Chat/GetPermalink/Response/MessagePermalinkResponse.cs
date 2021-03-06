﻿using System;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class MessagePermalinkResponse : SlackBaseResponse
	{
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		[JsonProperty("permalink")]
		public Uri Permalink { get; set; }
	}
}