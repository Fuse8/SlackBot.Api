using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class PinsClientMethods
	{
		public static async Task<SlackBaseResponse> PinMessageAsync(SlackClient slackClient, string channelName)
		{
			var (pinResponse, _) = await PinMessageInternalAsync(slackClient, channelName);

			return pinResponse;
		}
		
		public static async Task<PinListResponse> GetPinListAsync(SlackClient slackClient, string channelName)
		{
			var (_, sendMessageResponse) = await PinMessageInternalAsync(slackClient, channelName);
			await PinMessageInternalAsync(slackClient, channelName);

			return await slackClient.Pins.ListAsync(sendMessageResponse.ChannelId);
		}

		public static async Task<SlackBaseResponse> RemovePinAsync(SlackClient slackClient, string channelName)
		{
			var (_, sendMessageResponse) = await PinMessageInternalAsync(slackClient, channelName);
			
			return await slackClient.Pins.RemoveAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
		}

		private static async Task<(SlackBaseResponse PinResponse, SendMessageResponse SendMessageResponse)> PinMessageInternalAsync(
			SlackClient slackClient,
			string channelName)
		{
			var sendMessageResponse = await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelName, nameof(PinMessageInternalAsync));

			var pinItem = new PinItem(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
			var pinMessageResponse = await slackClient.Pins.PinAsync(pinItem);

			return (pinMessageResponse, sendMessageResponse);
		}
	}
}