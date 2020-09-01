using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Models;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;

namespace SlackBot.Samples
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var configuration = GetConfiguration();
			var slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");

			var slackClient = new SlackClient(slackBotSettings.Token);
			var message = new Message
			{
				Channel = "slack-bot-api-test",
				Text = "some message"
			};

			var postMessage = await slackClient.PostMessage(message);
		}

		private static IConfiguration GetConfiguration() =>
			new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", optional: true)
				.Build();
	}
}