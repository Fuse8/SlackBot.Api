namespace SlackBot.Api.Clients.Archive.Request
{
	public class ConversationToArchive : ConversationRequestBase
	{
		public ConversationToArchive()
		{
		}

		public ConversationToArchive(string channelId)
			: base(channelId)
		{
		}
	}
}