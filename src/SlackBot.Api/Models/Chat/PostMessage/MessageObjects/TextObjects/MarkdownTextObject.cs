using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects
{
	public class MarkdownTextObject : TextObjectBase
	{
		protected override string SectionType => "mrkdwn";

		[JsonProperty("verbatim")]
		public bool? Verbatim { get; set; }
		
		public static implicit operator MarkdownTextObject(string text)
			=> new MarkdownTextObject
			{
				Text = text,
			};
	}
}