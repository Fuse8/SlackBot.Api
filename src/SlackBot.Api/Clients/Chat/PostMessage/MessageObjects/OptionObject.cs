using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class OptionObject
	{
		/// <summary>
		/// A <see cref="TextObjectBase"/> that defines the text shown in the option on the menu.
		/// Overflow, "select" and "multi-select" menus can only use <see cref="PlainTextObject"/>, while "radio buttons" and "checkboxes" can use <see cref="MarkdownTextObject"/>.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is <strong>75 characters</strong>.
		/// </summary>
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }

		/// <summary>
		/// The string value that will be passed to your app when this option is chosen. Maximum length for this field is <strong>75 characters</strong>.
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// A <see cref="PlainTextObject"/> that defines a line of descriptive text shown below the <see cref="TextObjectBase.Text"/> field beside the radio button.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> within this field is <strong>75 characters</strong>.
		/// </summary>
		[JsonProperty("description")]
		public PlainTextObject Description { get; set; }

		/// <summary>
		/// A URL to load in the user's browser when the option is clicked. The <see cref="Url"/> attribute is only available in "overflow menus".
		/// Maximum length for this field is <strong>3000 characters</strong>.
		/// If you're using <see cref="Url"/>, you'll still receive an "interaction payload" and will need to send an "acknowledgement response".
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }
	}
}