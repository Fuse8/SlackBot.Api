using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements
{
	public class ImageElement : ActionElementBase
	{
		protected override string SectionType => "image";

		[JsonProperty("image_url")]
		public Uri ImageUrl { get; set; }
		
		[JsonProperty("alt_text")]
		public string AltText { get; set; }
	}
}