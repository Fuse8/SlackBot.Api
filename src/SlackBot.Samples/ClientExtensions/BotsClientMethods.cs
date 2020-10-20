using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class BotsClientMethods
	{
		public static async Task<BotInfoResponse> GetBotInfoAsync(SlackClient slackClient, string channelName)
		{
			var sendMessageResponse = await ChatClientMethods.SendSimpleMessageAsync(slackClient, channelName, nameof(GetBotInfoAsync));
			
			return await slackClient.Bots.InfoAsync(sendMessageResponse.Message.BotId);
		}
	}
}