namespace SlackBot.Api.Models.Chat.PostMessage.Request.Sections
{
	public class MrkdwnTextSection : TextSectionBase
	{
		protected override string SectionType => "mrkdwn";
	}
}