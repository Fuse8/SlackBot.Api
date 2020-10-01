namespace SlackBot.Api.Clients.Join.Request
{
	public class ConversationToJoin : ConversationRequestBase
	{
		public ConversationToJoin()
		{
		}

		public ConversationToJoin(string channelId)
			: base(channelId)
		{
		}
	}
}