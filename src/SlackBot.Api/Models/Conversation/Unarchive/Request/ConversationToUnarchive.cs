namespace SlackBot.Api.Models.Conversation.Unarchive.Request
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