namespace SlackBot.Api.Clients.Leave.Request
{
	public class ConversationToLeave : ConversationRequestBase
	{
		public ConversationToLeave()
		{
		}

		public ConversationToLeave(string channelId)
			: base(channelId)
		{
		}
	}
}