using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlackBot.Api;
using SlackBot.Api.Models;
using Microsoft.Extensions.Hosting;
using SlackBot.Api.Models.UploadFile.RequestModels;
using SlackBot.Api.Models.UploadFile.ResponseModels;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;

namespace SlackBot.Samples
{
    public class Program
    {
        const string EnvironmentVariableName = "ASPNETCORE_ENVIRONMENT";
        
        public static async Task Main(string[] args)
        {
            var host = BuildHost(args);
            
            using var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            
            var configuration = serviceProvider.GetService<IConfiguration>();
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
                Channel = "slack-bot-api-test",
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
        }

        private static IHost BuildHost(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            var environment = ParseEnvironment();
            if (!string.IsNullOrEmpty(environment))
            {
                hostBuilder.UseEnvironment(environment);
            }
            
            return hostBuilder.Build();
        }

        private static string ParseEnvironment() 
            => Environment.GetEnvironmentVariable(EnvironmentVariableName);
    }
}