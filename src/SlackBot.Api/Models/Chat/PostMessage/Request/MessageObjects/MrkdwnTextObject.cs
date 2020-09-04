namespace SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects
{
	public class MrkdwnTextObject : TextObjectBase
	{
		protected override string SectionType => "mrkdwn";

		public static implicit operator MrkdwnTextObject(string text) =>
			new MrkdwnTextObject
			{
				Text = text
			};
	}
}