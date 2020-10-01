namespace SlackBot.Api.Clients
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