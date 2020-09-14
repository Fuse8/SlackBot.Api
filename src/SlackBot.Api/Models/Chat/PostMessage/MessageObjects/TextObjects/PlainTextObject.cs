using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects
{
	public class PlainTextObject : TextObjectBase
	{
		protected override string SectionType => "plain_text";
		
		[JsonProperty("emoji")]
		public bool? UseEmoji { get; set; }
		
		public static implicit operator PlainTextObject(string text) =>
			new PlainTextObject
			{
				Text = text
			};
	}
}