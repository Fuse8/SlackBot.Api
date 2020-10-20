namespace SlackBot.Api
{
	public class ConversationToClose : ConversationRequestBase
	{
		public ConversationToClose()
		{
		}

		public ConversationToClose(string channelId)
			: base(channelId)
		{
		}
	}
}