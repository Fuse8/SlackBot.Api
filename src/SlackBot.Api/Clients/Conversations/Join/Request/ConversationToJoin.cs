namespace SlackBot.Api
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