namespace SlackBot.Api.Models.Conversation.Join.Request
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