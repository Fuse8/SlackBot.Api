using System.IO;
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
		private const string Channel = "slack-bot-api-test";

		public static async Task Main(string[] args)
		{
			var configuration = GetConfiguration();
			var slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");

			var slackClient = new SlackClient(slackBotSettings.Token);

			// Post message
			/* * /
			var message = new Message
			{
				Channel = Channel,
				Text = "some message"
			};
			var postMessage = await slackClient.PostMessage(message);
			/**/

			// Upload plain file content 
			/*	* /
			var content = await File.ReadAllTextAsync("./appsettings.json");

			var plainText = new UploadFile
			{
				Channels = Channel,
				Content = content
			};

			var fileResponse = await slackClient.UploadFile(plainText);
			/**/

			// Upload file from disk 
			/* * /
			await using var fileStream = File.Open("./appsettings.json", FileMode.Open);

			var uploadFile = new UploadFile
			{
				Channels = Channel,
				File = fileStream,
				Filename = "settings.json"
			};

			var fileResponse = await slackClient.UploadFile(uploadFile);
			/**/
			
			// Gets list of bot channels  
			/* */

			var userConversations = new UserConversations
			{
				Types = "public_channel,private_channel,mpim,im"
			};

			var conversationList = await slackClient.UserConversations(userConversations);
			/**/
		}

		private static IConfiguration GetConfiguration() =>
			new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", optional: true)
				.Build();
	}
}