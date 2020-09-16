﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Models.Chat.PostMessage;
using SlackBot.Api.Models.Chat.PostMessage.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Blocks;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageAttachment;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;
using SlackBot.Api.Models.Chat.PostMessage.Response;
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

		// ReSharper disable once InconsistentNaming
		public static async Task Main(string[] args)
		{
			var configuration = GetConfiguration();
			var slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");

			var slackClient = new SlackClient(slackBotSettings.Token);

			/* */
			var postMessageResponse = await PostMessageWithBlocksAsync(slackClient); /**/

			/* */
			var postMessageWithFilesResponse = await PostMessageWithMultipleFilesAsync(slackClient); /**/

			// Upload plain file content 
			/* */
			var uploadContentResponse = await UploadContentAsync(slackClient); /**/

			// Upload file from disk 
			/* */
			var uploadFileResponse = await UploadFileAsync(slackClient); /**/

			// Gets list of bot channels
			/* */
			var userConversationsResponse = await GetUserConversationsAsync(slackClient); /**/
		}

		private static Task<PostMessageResponse> PostMessageWithBlocksAsync(SlackClient slackClient)
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
							Confirm = new ConfirmObject
							{
								Title = "Action Block confirmation",
								Confirm = "Sure",
								Deny = "Nope",
								Text = "I wanna open google",
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
					Text = new PlainTextObject
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

			var message = new Message
			{
				Channel = Channel,
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
				Channel = Channel,
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

		private static async Task<UploadFileResponse> UploadContentAsync(SlackClient slackClient)
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			var contentMessage = new ContentToUpload
			{
				Comment = "Upload content",
				Title = "Title",
				Channels = Channel,
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
				Channels = Channel,
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

		private static IConfiguration GetConfiguration()
			=> new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.AddJsonFile("appsettings.Development.json", true)
				.Build();
	}
}