using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class SectionBlock : BlockBase
	{
		protected override string SectionType => "section";

		/// <summary>
		/// The text for the block, in the form of a <see cref="TextObjectBase"/>. Maximum length for the <see cref="TextObjectBase.Text"/> in this field is <strong>3000 characters</strong>.
		/// This field is not required if a valid <see cref="Fields"/> of fields objects is provided instead.
		/// </summary>
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }

		/// <summary>
		/// An array of <see cref="TextObjectBase"/>.
		/// Any text objects included with <see cref="Fields"/> will be rendered in a compact format that allows for 2 columns of side-by-side text.
		/// Maximum number of items is <strong>10. Maximum length for the <see cref="TextObjectBase.Text"/> in each item is 2000 characters</strong>.
		/// </summary>
		[JsonProperty("fields")]
		public List<TextObjectBase> Fields { get; set; }

		/// <summary>
		/// One of the available <see cref="ISectionElement"/> objects.
		/// </summary>
		[JsonProperty("accessory")]
		public ISectionElement Accessory { get; set; }
	}
}