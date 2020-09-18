using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models;
using SlackBot.Api.Models.Chat.DeleteScheduledMessage.Request;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Chat.PostMessage.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Blocks;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageAttachment;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.Chat.ScheduledMessagesList.Request;
using SlackBot.Api.Models.Chat.ScheduledMessagesList.Response;
using SlackBot.Api.Models.Chat.ScheduleMessage.Request;
using SlackBot.Api.Models.Chat.ScheduleMessage.Response;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;


#region disable formatting rules
	
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedVariable
#pragma warning disable 1998

#endregion

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

		// ReSharper disable once InconsistentNaming
		public static async Task Main(string[] args)
		{
			var slackClient = SlackClientFactory.CreateSlackClient(_slackBotSettings.Token);

			/* Sends message with some blocks * /
			var postMessageResponse = await PostMessageWithBlocksAsync(slackClient); /**/

			/* Uploads some files and sends message with them * /
			var postMessageWithFilesResponse = await PostMessageWithMultipleFilesAsync(slackClient); /**/
			
			/* Schedules message to channel * /
			var scheduleMessageResponse = await ScheduleMessageAsync(slackClient); /**/
			
			/* Gets list of scheduled messages * /
			var scheduledMessageListResponse = await GetScheduledMessagesAsync(slackClient); /**/
			
			/* Delete scheduled message * /
			var deleteScheduledMessageResponse = await DeleteScheduledMessageAsync(slackClient); /**/

			/* Uploads plain file content * /
			var uploadContentResponse = await UploadContentAsync(slackClient); /**/
 
			/* Uploads file from disk * /
			var uploadFileResponse = await UploadFileAsync(slackClient); /**/

            /* Gets list of bot channels * /
			var userConversationsResponse = await GetUserConversationsAsync(slackClient);/**/
            
            /* Gets conversation's history of messages and events * /
			var conversationsHistoryResponse = await GetConversationsHistoryAsync(slackClient);/**/
		}

		private static Task<PostMessageResponse> PostMessageWithBlocksAsync(SlackClient slackClient)
		{
			var blocks = GenerateBlocksForMessage();

			var message = new Message
			{
				Channel = _slackBotSettings.ChannelName,
				Blocks = blocks,
				Text = "ala",
				Attachments = new[]
				{
					new Attachment
					{
						Color = "#36a64f",
						Blocks = blocks,
					},
				},
			};

			return slackClient.PostMessageAsync(message);
		}

		private static async Task<PostMessageResponse> PostMessageWithMultipleFilesAsync(SlackClient slackClient)
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");

			// Upload files without Channel
			var contentMessage = new ContentToUpload
			{
				Comment = "Upload content",
				Title = "File1",
				Content = content,
				Filename = "appsettings.json",
				FileType = "javascript",
			};

			var firstFile = await slackClient.UploadContentAsync(contentMessage);

			contentMessage.Title = "File2";
			var secondFile = await slackClient.UploadContentAsync(contentMessage);

			var message = new Message
			{
				Channel = _slackBotSettings.ChannelName,
				Text = firstFile.File.Permalink + " " + secondFile.File.Permalink,
				Blocks = new BlockBase[]
				{
					new ContextBlock
					{
						Elements = new IContextElement[]
						{
							(PlainTextObject)"Some text",
						},
					},
				},
			};

			return await slackClient.PostMessageAsync(message);
		}

		private static Task<ScheduleMessageResponse> ScheduleMessageAsync(SlackClient slackClient, int minutesToSchedule = 1)
		{
			const string DateTimeFormat = "dd MMMM yyyy HH:mm:ss tt";
			var now = DateTime.Now;
			var scheduledDateTime =now.AddMinutes(minutesToSchedule);
			
			var scheduledMessage = new MessageToSchedule
			{
				Channel = _slackBotSettings.ChannelName,
				Text = $"Scheduled message\nNow dateTime - {now.ToString(DateTimeFormat)}\nScheduled dateTime - {scheduledDateTime.ToString(DateTimeFormat)}",
				PostAt = UnixTimeHelper.ToUnixTime(scheduledDateTime)
			};

			return slackClient.ScheduleMessageAsync(scheduledMessage);
		}
		
		private static async Task<ScheduledMessagesResponse> GetScheduledMessagesAsync(SlackClient slackClient)
		{
			const int MinutesToSchedule = 2;
			var scheduleMessage1 = await ScheduleMessageAsync(slackClient, MinutesToSchedule);
			var scheduleMessage2 = await ScheduleMessageAsync(slackClient, MinutesToSchedule);

			var getScheduledMessagesRequest = new GetScheduledMessagesRequest
			{
				ChannelId = scheduleMessage2?.ChannelId
			};

			return await slackClient.GetScheduledMessages(getScheduledMessagesRequest);
		}
		
		private static async Task<SlackBaseResponse> DeleteScheduledMessageAsync(SlackClient slackClient)
		{
			var scheduleMessageResponse = await ScheduleMessageAsync(slackClient, 2);
			
			var deleteScheduledMessageRequest = new DeleteScheduledMessageRequest
			{
				Channel = scheduleMessageResponse.ChannelId,
				ScheduledMessageId = scheduleMessageResponse.ScheduledMessageId
			};

			return await slackClient.DeleteScheduledMessageAsync(deleteScheduledMessageRequest);
		}

		private static async Task<UploadFileResponse> UploadContentAsync(SlackClient slackClient)
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			var contentMessage = new ContentToUpload
			{
				Comment = "Upload content",
				Title = "Title",
				Channels = _slackBotSettings.ChannelName,
				Content = content,
				Filename = "appsettings.json",
				FileType = "javascript",
			};

			return await slackClient.UploadContentAsync(contentMessage);
		}

		private static async Task<UploadFileResponse> UploadFileAsync(SlackClient slackClient)
		{
			await using var fileStream = File.Open("./appsettings.json", FileMode.Open);
			var fileMessage = new FileToUpload
			{
				Channels = _slackBotSettings.ChannelName,
				Stream = fileStream,
			};

			return await slackClient.UploadFileAsync(fileMessage);
		}

		private static Task<ConversationResponse> GetUserConversationsAsync(SlackClient slackClient)
		{
			var userConversations = new UserConversations
			{
				Types = "public_channel,private_channel,mpim,im",
			};

			return slackClient.UserConversationsAsync(userConversations);
        }
        
        private static async Task<ConversationsHistoryResponse> GetConversationsHistoryAsync(SlackClient slackClient)
        {
	        var channelId = await GetChannelIdAsync(slackClient);

	        var conversationsHistory = new ConversationsHistory(channelId, 1000);

	        return await slackClient.ConversationsHistoryAsync(conversationsHistory);
        }
        
        private static async Task<string> GetChannelIdAsync(SlackClient slackClient)
        {
	        var userConversations = new UserConversations
	        {
		        Types = "public_channel,private_channel,mpim,im"
	        };

	        var conversationsHistoryResponse = await slackClient.UserConversationsAsync(userConversations);
	        var channelId = conversationsHistoryResponse?.Channels?.FirstOrDefault(p => p.Name == _slackBotSettings.ChannelName)?.Id;

	        return channelId;
		}

		private static BlockBase[] GenerateBlocksForMessage()
		{
			var blocks = new BlockBase[]
			{
				new ActionBlock
				{
					Elements = new IActionElement[]
					{
						new ButtonActionElement
						{
							Text = new PlainTextObject
							{
								UseEmoji = true,
								Text = ":cat: Button",
							},
							Url = new Uri("https://google.com"),
							Confirm = new ConfirmationDialogObject
							{
								Title = "Action Block confirmation",
								Confirm = "Sure",
								Deny = "Nope",
								Text = (PlainTextObject)"I wanna open google",
							},
						},

						new DatepickerActionElement
						{
							Placeholder = "Select date",
							InitialDate = "2020-02-22",
						},
					},
				},
				new ContextBlock
				{
					Elements = new IContextElement[]
					{
						(PlainTextObject)"This is Context Block",
						new ImageElement
						{
							AltText = "Kitty in the Context block",
							ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
						},
					},
				},
				new DividerBlock(),
				new HeaderBlock
				{
					Text = "This is Header Block",
				},
				new ImageBlock
				{
					ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
					Title = new PlainTextObject
					{
						UseEmoji = true,
						Text = ":cat:",
					},
					AltText = "Kitty",
				},
				new SectionBlock
				{
					Text = (PlainTextObject)"This is Section Block",
					Fields = new TextObjectBase[]
					{
						(MarkdownTextObject)"*Bold Text*",
						(MarkdownTextObject)"_Italic Text_",
					},
					Accessory = new ImageElement
					{
						AltText = "Kitty in the Section block",
						ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
					},
				},
			};
			return blocks;
		}

		private static IConfiguration GetConfiguration()
			=> new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", true)
				.Build();
	}
}