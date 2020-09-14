using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Response
{
	public class BotIcons
	{
		[JsonProperty("image_36")]
		public Uri Image36 { get; set; }

		[JsonProperty("image_48")]
		public Uri Image48 { get; set; }

		[JsonProperty("image_72")]
		public Uri Image72 { get; set; }
	}
}