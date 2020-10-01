namespace SlackBot.Api.Clients.Close.Request
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