using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
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
            
			/* * /var postMessageResponse = await PostMessage(slackClient);/**/
            
            // Upload plain file content 
            /* * /var uploadContentResponse = await UploadContent(slackClient);/**/
            
            // Upload file from disk 
            /* * /var uploadFileResponse = await UploadFile(slackClient);/**/
            
            // Gets list of bot channels
            /* * /var userConversationsResponse = await GetUserConversations(slackClient);/**/
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
        
        private static async Task<UploadFileResponse> UploadContent(SlackClient slackClient)
        {
	        var content = await File.ReadAllTextAsync("./appsettings.json");
            var contentMessage = new ContentToUpload
            {
                Comment = "Upload content",
                Title = "Title",
                Channels = "slack-bot-api-test",
                Content = content,
                Filename = "appsettings.json",
                FileType = "javascript"
            };

            return await slackClient.UploadContent(contentMessage);
        }
        
        private static async Task<UploadFileResponse> UploadFile(SlackClient slackClient)
        {
	        await using var fileStream = File.Open("./appsettings.json", FileMode.Open);
            var fileMessage = new FileToUpload
            {
                Channels = "slack-bot-api-test",
                Stream =  fileStream,
            };

            return await slackClient.UploadFile(fileMessage);
		}
        
        private static Task<ConversationResponse> GetUserConversations(SlackClient slackClient)
        {
	        var userConversations = new UserConversations
	        {
		        Types = "public_channel,private_channel,mpim,im"
	        };

	        return slackClient.UserConversations(userConversations);
        }

		private static IConfiguration GetConfiguration() =>
			new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", optional: true)
				.Build();
	}
}