using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class DividerBlock : BlockBase
	{
		protected override string SectionType => "divider";
	}
}