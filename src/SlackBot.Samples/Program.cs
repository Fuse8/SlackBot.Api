using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlackBot.Api;
using SlackBot.Api.Models;
using Microsoft.Extensions.Hosting;
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
            var message = new Message
            {
                Channel = "slack-bot-api-test",
                Text = "some message"
            };
            
            var postMessage = await slackClient.PostMessage(message);
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