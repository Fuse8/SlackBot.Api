using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.BlockElements
{
	public class ImageElement : ObjectWithType, ISectionElement, IContextElement
	{
		protected override string SectionType => "image";

		[JsonProperty("image_url")]
		public Uri ImageUrl { get; set; }
		
		[JsonProperty("alt_text")]
		public string AltText { get; set; }
	}
}