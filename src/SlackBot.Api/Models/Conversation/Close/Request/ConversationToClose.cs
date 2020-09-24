namespace SlackBot.Api.Models.Conversation.Close.Request
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