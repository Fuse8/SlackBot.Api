using SlackBot.Api.Clients.PostMessage.Contracts;

namespace SlackBot.Api.Clients.PostMessage.Blocks
{
	public class DividerBlock : BlockBase
	{
		protected override string SectionType => "divider";
	}
}