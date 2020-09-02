using System.IO;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Models;
using SlackBot.Api.Models.UploadFile.RequestModels;
using SlackBot.Api.Models.UploadFile.ResponseModels;
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
            
            //var postMessageResponse = await PostMessage(slackClient);
            
            //var uploadContentResponse = await UploadContent(slackClient);
            
            var uploadFileResponse = await UploadFile(slackClient);
        }

        private static Task<MessageResponse> PostMessage(SlackClient slackClient)
        {
			var message = new Message
			{
				Channel = Channel,
				Text = "some message"
			};
            return slackClient.PostMessage(message);
        }
        
        private static Task<UploadFileResponse> UploadContent(SlackClient slackClient)
        {
            var contentMessage = new ContentMessage
            {
                initial_comment = "Comment",
                title = "Title",
                channels = "slack-bot-api-test",
                content = "Content text",
                filename = "File name.txt",
                filetype = "auto"
            };

            return slackClient.UploadContent(contentMessage);
        }
        
        private static Task<UploadFileResponse> UploadFile(SlackClient slackClient)
        {
            var fileMessage = new FileMessage
            {
                initial_comment = "Comment",
                title = "Title",
                channels = "slack-bot-api-test",
                filename = "File name.txt",
                filetype = "auto",
                file = File.OpenRead(@"C:\Users\feudork\Downloads\stamp3.jpeg")
            };

            return slackClient.UploadFile(fileMessage);

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