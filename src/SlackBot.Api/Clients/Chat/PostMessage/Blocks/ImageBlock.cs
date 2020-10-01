using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ImageBlock : BlockBase
	{
		protected override string SectionType => "image";

		/// <summary>
		/// The URL of the image to be displayed. Maximum length for this field is <strong>3000 characters</strong>.
		/// </summary>
		[JsonProperty("image_url")]
		public Uri ImageUrl { get; set; }

		/// <summary>
		/// A plain-text summary of the image. This should not contain any markup. Maximum length for this field is <strong>2000 characters</strong>.
		/// </summary>
		[JsonProperty("alt_text")]
		public string AltText { get; set; }

		/// <summary>
		/// An optional title for the image in the form of a text object that can only be of type: <see cref="PlainTextObject"/>.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is <strong>2000 characters</strong>.
		/// </summary>
		[JsonProperty("title")]
		public PlainTextObject Title { get; set; }
	}
}