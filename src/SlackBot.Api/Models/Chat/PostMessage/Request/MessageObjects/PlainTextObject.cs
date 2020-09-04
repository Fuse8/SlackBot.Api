using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects
{
	public class PlainTextObject : TextObjectBase
	{
		protected override string SectionType => "plain_text";
		
		[JsonProperty("emoji")]
		public bool? Emoji { get; set; }
		
		public static implicit operator PlainTextObject(string text) =>
			new PlainTextObject
			{
				Text = text
			};
	}
}