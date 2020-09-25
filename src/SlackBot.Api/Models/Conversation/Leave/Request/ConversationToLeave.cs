namespace SlackBot.Api.Models.Conversation.Leave.Request
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