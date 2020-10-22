namespace SlackBot.Api
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