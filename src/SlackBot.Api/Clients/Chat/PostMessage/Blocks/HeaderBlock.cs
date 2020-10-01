using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage.Contracts;
using SlackBot.Api.Clients.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Clients.PostMessage.Blocks
{
	public class HeaderBlock : BlockBase
	{
		protected override string SectionType => "header";

		/// <summary>
		/// The text for the block, in the form of a <see cref="PlainTextObject"/> text object.
		/// Maximum length for the <see cref="Text"/> in this field is <strong>3000 characters</strong>.
		/// </summary>
		[JsonProperty("text")]
		public PlainTextObject Text { get; set; }
	}
}