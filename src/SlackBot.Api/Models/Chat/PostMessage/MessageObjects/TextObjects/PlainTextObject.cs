using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects
{
	public class PlainTextObject : TextObjectBase
	{
		protected override string SectionType => "plain_text";

		/// <summary>
		/// Indicates whether emojis in a text field should be escaped into the colon emoji format.
		/// This field is only usable when <see cref="ObjectWithType.Type"/> is "plain_text".
		/// </summary>
		[JsonProperty("emoji")]
		public bool? UseEmoji { get; set; }

		public static implicit operator PlainTextObject(string text)
			=> new PlainTextObject
			{
				Text = text,
			};
	}
}