using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;
using MessageResponse = SlackBot.Api.Models.Chat.PostMessage.MessageResponse;

namespace SlackBot.Samples
{
	public class Program
	{
		private static readonly SlackBotSettings _slackBotSettings;

		static Program()
		{
			var configuration = GetConfiguration();
			_slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");
		}

		public static async Task Main(string[] args)
		{
			var slackClient = new SlackClient(_slackBotSettings.Token);
            
			/* * /var postMessageResponse = await PostMessage(slackClient);/**/
            
            // Upload plain file content 
            /* * /var uploadContentResponse = await UploadContent(slackClient);/**/
            
            // Upload file from disk 
            /* * /var uploadFileResponse = await UploadFile(slackClient);/**/
            
            // Gets list of bot channels
            /* * /var userConversationsResponse = await GetUserConversations(slackClient);/**/
            
            // Gets conversation's history of messages and events.
            /* */var conversationsHistoryResponse = await GetConversationsHistory(slackClient);/**/

            var asd = conversationsHistoryResponse.Messages.Where(p => !string.IsNullOrEmpty(p.Subtype)).ToList();
            var starred = conversationsHistoryResponse.Messages.Where(p => p.IsStarred.GetValueOrDefault()).ToList();
            var commented = conversationsHistoryResponse.Messages.Where(p => p.Comment != null).ToList();
            var deleted = conversationsHistoryResponse.Messages.Where(p => p.DeletedTimestamp != null).ToList();
            var edited = conversationsHistoryResponse.Messages.Where(p => p.EditedInfo != null).ToList();
            var filed = conversationsHistoryResponse.Messages.Where(p => p.File != null).ToList();
            var pinned = conversationsHistoryResponse.Messages.Where(p => p.PinnedToChannelIds != null && p.PinnedToChannelIds.Any()).ToList();
            var updated = conversationsHistoryResponse.Messages.Where(p => p.UpdatedMessage != null).ToList();
            var usenamed = conversationsHistoryResponse.Messages.Where(p => p.Username != null).ToList();
            var reacted = conversationsHistoryResponse.Messages.Where(p => p.Reactions != null && p.Reactions.Any()).ToList();
            var icons = conversationsHistoryResponse.Messages.Where(p => p.BotInfo != null).ToList();
            var files = conversationsHistoryResponse.Messages.Where(p => p.Files != null && p.Files.Any()).ToList();
		}

        private static Task<MessageResponse> PostMessage(SlackClient slackClient)
        {
			var message = new Message
			{
				Channel = _slackBotSettings.ChannelName,
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
        
        private static async Task<ConversationsHistoryResponse> GetConversationsHistory(SlackClient slackClient)
        {
	        var channelId = await GetChannelId(slackClient);
	        
	        var conversationsHistory = new ConversationsHistory
	        {
		        ChannelId = channelId,
		        Limit = 1000,
		        Latest = "1598951031.000400"
	        };

	        return await slackClient.ConversationsHistory(conversationsHistory);
        }
        
        private static async Task<string> GetChannelId(SlackClient slackClient)
        {
	        var userConversations = new UserConversations
	        {
		        Types = "public_channel,private_channel,mpim,im"
	        };

	        var conversationsHistoryResponse = await slackClient.UserConversations(userConversations);
	        var channelId = conversationsHistoryResponse?.Channels?.FirstOrDefault(p => p.Name == _slackBotSettings.ChannelName)?.Id;

	        return channelId;
        }

		private static IConfiguration GetConfiguration() =>
			new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", optional: true)
				.Build();
	}
}