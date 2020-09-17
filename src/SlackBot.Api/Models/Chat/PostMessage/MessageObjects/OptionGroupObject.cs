using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	public class OptionGroupObject
	{
		/// <summary>
		/// A <see cref="PlainTextObject"/> that defines the label shown above this group of options.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is 75 characters.
		/// </summary>
		[JsonProperty("label")]
		public PlainTextObject Label { get; set; }

		/// <summary>
		/// An array of <see cref="OptionObject"/> that belong to this specific group. Maximum of 100 items.
		/// </summary>
		[JsonProperty("options")] //TODO bold count of Maximum
		public OptionObject[] Options { get; set; }
	}
}