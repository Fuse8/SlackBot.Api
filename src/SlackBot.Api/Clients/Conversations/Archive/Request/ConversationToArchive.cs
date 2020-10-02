namespace SlackBot.Api
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