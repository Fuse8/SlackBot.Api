using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class SectionBlock : BlockBase
	{
		protected override string SectionType => "section";

		/// <summary>
		/// The text for the block, in the form of a <see cref="TextObjectBase"/>. Maximum length for the <see cref="TextObjectBase.Text"/> in this field is 3000 characters.
		/// This field is not required if a valid <see cref="Fields"/> of fields objects is provided instead.
		/// </summary>
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }

		/// <summary>
		/// An array of <see cref="TextObjectBase"/>.
		/// Any text objects included with <see cref="Fields"/> will be rendered in a compact format that allows for 2 columns of side-by-side text.
		/// Maximum number of items is 10. Maximum length for the <see cref="TextObjectBase.Text"/> in each item is 2000 characters.
		/// </summary>
		[JsonProperty("fields")]
		public TextObjectBase[] Fields { get; set; }

		/// <summary>
		/// One of the available <see cref="ISectionElement"/> objects.
		/// </summary>
		[JsonProperty("accessory")]
		public ISectionElement Accessory { get; set; }
	}
}