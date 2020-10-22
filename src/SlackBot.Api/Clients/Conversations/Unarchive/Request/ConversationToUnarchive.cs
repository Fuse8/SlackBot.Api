namespace SlackBot.Api
{
	public class ConversationToUnarchive : ConversationRequestBase
	{
		public ConversationToUnarchive()
		{
		}

		public ConversationToUnarchive(string channelId)
			: base(channelId)
		{
		}
	}
}