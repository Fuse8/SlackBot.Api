using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class ImageBlock : BlockBase
	{
		protected override string SectionType => "image";

		[JsonProperty("block_id")]
		public string BlockId { get; set; }

		[JsonProperty("image_url")]
		public Uri ImageUrl { get; set; }

		[JsonProperty("alt_text")]
		public string AltText { get; set; }

		[JsonProperty("title")]
		public PlainTextObject Text { get; set; }
	}
}