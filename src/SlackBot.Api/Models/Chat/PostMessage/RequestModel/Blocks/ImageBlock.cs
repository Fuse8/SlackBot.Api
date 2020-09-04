using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
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
		public PlainTextSection Text { get; set; }
	}
}