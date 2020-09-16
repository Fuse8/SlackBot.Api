namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects
{
	public class MarkdownTextObject : TextObjectBase
	{
		protected override string SectionType => "mrkdwn";

		public static implicit operator MarkdownTextObject(string text)
			=> new MarkdownTextObject
			{
				Text = text,
			};
	}
}