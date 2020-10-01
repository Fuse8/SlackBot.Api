namespace SlackBot.Api.Clients
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