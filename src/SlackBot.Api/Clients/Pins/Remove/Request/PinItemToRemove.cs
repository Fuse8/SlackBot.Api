using SlackBot.Api.Clients.GeneralObjects;

namespace SlackBot.Api.Clients.Remove.Request
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