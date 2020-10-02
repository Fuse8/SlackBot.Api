namespace SlackBot.Api
{
	public class PinItemToRemove : ItemActionRequestBase
	{
		public PinItemToRemove()
		{
		}

		public PinItemToRemove(string channelId, string messageTimestamp)
			: base(channelId, messageTimestamp)
		{
		}
	}
}