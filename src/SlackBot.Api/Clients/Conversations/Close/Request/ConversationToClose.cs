namespace SlackBot.Api.Clients
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