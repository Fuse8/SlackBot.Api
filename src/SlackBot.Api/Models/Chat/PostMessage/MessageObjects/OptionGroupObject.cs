using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	public class OptionGroupObject
	{
		/// <summary>
		/// A <see cref="PlainTextObject"/> that defines the label shown above this group of options.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is <strong>75 characters</strong>.
		/// </summary>
		[JsonProperty("label")]
		public PlainTextObject Label { get; set; }

		/// <summary>
		/// An array of <see cref="OptionObject"/> that belong to this specific group. Maximum of <strong>100 items</strong>.
		/// </summary>
		[JsonProperty("options")]
		public OptionObject[] Options { get; set; }
	}
}