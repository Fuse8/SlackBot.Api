using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Pin.Remove.Request
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