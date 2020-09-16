using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	public class OptionObject
	{
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("description")]
		public PlainTextObject Description { get; set; }

		[JsonProperty("url")]
		public Uri Url { get; set; }
	}
}