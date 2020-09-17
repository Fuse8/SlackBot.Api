using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.BlockElements
{
	public class ImageElement : ObjectWithType, ISectionElement, IContextElement
	{
		protected override string SectionType => "image";

		/// <summary>
		/// The URL of the image to be displayed.
		/// </summary>
		[JsonProperty("image_url")]
		public Uri ImageUrl { get; set; }

		/// <summary>
		/// A plain-text summary of the image. This should not contain any markup.
		/// </summary>
		[JsonProperty("alt_text")]
		public string AltText { get; set; }
	}
}