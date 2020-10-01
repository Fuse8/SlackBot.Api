using System;
using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Clients.PostMessage.Enums;
using SlackBot.Api.Clients.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Clients.PostMessage.BlockElements
{
	public class ButtonActionElement : ActionElementBase, ISectionElement, IActionElement
	{
		protected override string SectionType => "button";

		/// <summary>
		/// A <see cref="TextObjectBase"/> that defines the button's text. Can only be of type: <see cref="PlainTextObject"/>.
		/// Maximum length for the <see cref="Text"/> in this field is <strong>75 characters</strong>.
		/// </summary>
		[JsonProperty("text")]
		public PlainTextObject Text { get; set; }

		/// <summary>
		/// A URL to load in the user's browser when the button is clicked. Maximum length for this field is <strong>3000 characters</strong>.
		/// If you're using <see cref="Url"/>, you'll still receive an "interaction payload" and will need to send an "acknowledgement response".
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// The value to send along with the "interaction payload". Maximum length for this field is <strong>2000 characters</strong>.
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// Decorates buttons with alternative visual color schemes. Use this option with restraint.
		/// <para><strong>Default: black button style</strong></para>
		/// </summary>
		[JsonProperty("style")]
		public StyleType? Style { get; set; }
	}
}