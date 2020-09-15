using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Chat.PostMessage.MessageAttachment;
using SlackBot.Api.Models.Chat.PostMessage.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Blocks;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;
using SlackBot.Api.Models.Chat.PostMessage.Response;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;

#region disable Resharper rules
	
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedVariable

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

		public static async Task Main(string[] args)
		{
			var slackClient = new SlackClient(_slackBotSettings.Token);
            
			/* * /var postMessageResponse = await PostMessageWithBlocks(slackClient);/**/
			
            /* * /var postMessageWithFilesResponse = await PostMessageWithMultipleFiles(slackClient);/**/ 
            
            // Upload plain file content 
            /* * /var uploadContentResponse = await UploadContent(slackClient);/**/
            
            // Upload file from disk 
            /* * /var uploadFileResponse = await UploadFile(slackClient);/**/
            
            // Gets list of bot channels
            /* * /var userConversationsResponse = await GetUserConversations(slackClient);/**/
            
            // Gets conversation's history of messages and events.
            /* */var conversationsHistoryResponse = await GetConversationsHistory(slackClient);/**/
		}

		private static Task<PostMessageResponse> PostMessageWithBlocks(SlackClient slackClient)
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
								Text = ":cat: Button"
							},
							Url = new Uri("https://google.com"),
							Confirm = new ConfirmObject
							{
								Title = "Action Block confirmation",
								Confirm = "Sure",
								Deny = "Nope",
								Text = "I wanna open google"
							}
						},

						new DatepickerActionElement
						{
							Placeholder = "Select date",
							InitialDate = "2020-02-22",
						},
					}
				},
				new ContextBlock
				{
					Elements = new IContextElement[]
					{
						(PlainTextObject) "This is Context Block",
						new ImageElement
						{
							AltText = "Kitty in the Context block",
							ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
						},
					}
				},
				new DividerBlock(),
				new HeaderBlock
				{
					Text = "This is Header Block"
				},
				new ImageBlock
				{
					ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
					Text = new PlainTextObject
					{
						UseEmoji = true,
						Text = ":cat:"
					},
					AltText = "Kitty"
				},
				new SectionBlock
				{
					Text = (PlainTextObject) "This is Section Block",
					Fields = new TextObjectBase[]
					{
						(MrkdwnTextObject) "*Bold Text*",
						(MrkdwnTextObject) "_Italic Text_"
					},
					Accessory = new ImageElement
					{
						AltText = "Kitty in the Section block",
						ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
					},
				},
			};
			
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
						Blocks = blocks
					}, 
				}
			};
			
			return slackClient.PostMessage(message);
		}
		
		private static  async Task<PostMessageResponse> PostMessageWithMultipleFiles(SlackClient slackClient)
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			
			// Upload files without Channel
			var contentMessage = new ContentToUpload
			{
				Comment = "Upload content",
				Title = "File1",
				Content = content,
				Filename = "appsettings.json",
				FileType = "javascript"
			};

			var firstFile = await slackClient.UploadContent(contentMessage);
			
			contentMessage.Title = "File2";
			var secondFile = await slackClient.UploadContent(contentMessage);
			
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
							(PlainTextObject) "Some text", 
						}
					}
				}
			};
			
			return await slackClient.PostMessage(message);
		}

		private static async Task<UploadFileResponse> UploadContent(SlackClient slackClient)
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			var contentMessage = new ContentToUpload
			{
				Comment = "Upload content",
				Title = "Title",
				Channels = _slackBotSettings.ChannelName,
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
				Channels = _slackBotSettings.ChannelName,
				Stream = fileStream,
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

	        var conversationsHistory = new ConversationsHistory(channelId, 1000);

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
