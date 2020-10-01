namespace SlackBot.Api.Clients.Unarchive.Request
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