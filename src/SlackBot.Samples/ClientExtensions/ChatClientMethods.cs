using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlackBot.Api;
using SlackBot.Api.Enums;
using SlackBot.Api.Helpers;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class ChatClientMethods
	{
		public static Task<SendMessageResponse> SendMessageWithBlocksAsync(SlackClient slackClient, string channelName)
		{
			var blocks = GenerateBlocks();

			var message = new SlackMessage
			{
				ChannelIdOrName = channelName,
				Blocks = blocks,
				Text = $"{nameof(SendMessageWithBlocksAsync)} method",
				Attachments = new List<Attachment>
				{
					new Attachment
					{
						Color = "#36a64f",
						Blocks = blocks,
					},
				},
			};

			return slackClient.Chat.PostMessageAsync(message);
		}

		public static async Task<SendMessageResponse> SendMessageWithMultipleFilesAsync(SlackClient slackClient, string channelName)
		{
			var firstFile = await FilesClientMethods.UploadContentAsync(slackClient, channelName, "File1");

			var secondFile = await FilesClientMethods.UploadContentAsync(slackClient, channelName, "File2");

			var message = new SlackMessage
			{
				ChannelIdOrName = channelName,
				Text = firstFile.File.Permalink + " " + secondFile.File.Permalink,
				Blocks = new List<BlockBase>
				{
					new ContextBlock
					{
						Elements = new List<IContextElement>
						{
							(PlainTextObject)$"{nameof(SendMessageWithMultipleFilesAsync)} method",
						},
					},
				},
			};

			return await slackClient.Chat.PostMessageAsync(message);
		}
		
		public static async Task<(
			SendMessageResponse MessageWithTextHelperResponse, 
			SendMessageResponse MessageWithTextBuilderResponse, 
			SendMessageResponse MessageWithBlocksResponse)> SendMessagesWithBuilderAsync(SlackClient slackClient, string channelName, string userId)
		{
			const string SampleUrl = "https://api.slack.com/";
			var now = DateTime.Now;
			var nowTimestamp = UnixTimeHelper.ToUnixTime(now);
			var channelId = await ConversationsClientMethods.GetChannelIdAsync(slackClient, channelName);

			var messageWithTextHelper = new MessageBuilder(channelName)
				.Text($"Channel mention by {nameof(TextHelper)}: {TextHelper.ChannelMention(SlackMention.Channel)}")
				.LineBreak()
				.Text($"Users mention by {nameof(TextHelper)}: {TextHelper.UserMentions(new[] { userId, userId })}")
				.LineBreak()
				.Text($"Public channel mention by {nameof(TextHelper)}: {TextHelper.PublicChannelMention(channelId)}")
				.LineBreak()
				.Text($"{TextHelper.Bold("bold text")} by {nameof(TextHelper)}")
				.LineBreak()
				.Text($"{TextHelper.InlineCode("inline code")} by {nameof(TextHelper)}")
				.LineBreak()
				.Text($"{TextHelper.Strike("strike text")} by {nameof(TextHelper)}")
				.LineBreak()
				.Text($"{TextHelper.Italic("italic text")} by {nameof(TextHelper)}")
				.LineBreak()
				.Text($"Link by {nameof(TextHelper)}: {TextHelper.Link(SampleUrl)}")
				.LineBreak()
				.Text($"Link by {nameof(TextHelper)}: {TextHelper.Link(new Uri(SampleUrl))}")
				.LineBreak()
				.Text($"Link by {nameof(TextHelper)}: {TextHelper.EmailLink("test@test.com")}")
				.LineBreak()
				.LineBreak()
				.Text($"Code block by {nameof(TextHelper)}:{TextHelper.CodeBlock("code line #1\ncode line #2")}")
				.LineBreak()
				.LineBreak()
				.Text($"Unquoted text by {nameof(TextHelper)}:{TextHelper.Quoted("quoted text #1\nquoted text #2")}Unquoted text again")
				.LineBreak()
				.LineBreak()
				.Text($"List by {nameof(TextHelper)}:{TextHelper.List("list item #1", "list item #2")}")
				.LineBreak()
				.LineBreak()
				.Text($"User mention by {nameof(TextHelper)}: {TextHelper.UserMention(userId)}")
				.LineBreak()
				.Text(TextHelper.Date(nowTimestamp, $"Date by {nameof(TextHelper)}: {{date_num}} {{time}}", now.ToString("yyyy-MM-dd hh:mm")));

			var messageWithTextBuilder = new MessageBuilder(channelId)
				.ChannelMention(SlackMention.Here)
				.UserMentions(new[] { userId, userId }, "\n")
				.PublicChannelMention(channelId, "\n")
				.BoldText("bold text", "\n")
				.InlineCodeText("inline code", "\n")
				.StrikeText("strike text", TextHelper.LineBreak)
				.ItalicText("italic text", TextHelper.LineBreak)
				.CodeBlock("code block", TextHelper.LineBreak)
				.LinkText(SampleUrl, "Slack api url", TextHelper.LineBreak)
				.LinkText(new Uri(SampleUrl), "Slack api url", TextHelper.LineBreak)
				.EmailLinkText("test@test.com", "Test email", TextHelper.LineBreak)
				.QuotedText("quoted text #1")
				.QuotedText("quoted text #2")
				.ListText(new[] { "list item #1", "list item #2" })
				.UserMention(userId)
				.Date(nowTimestamp, "{date_num} {time}", now.ToString("yyyy-MM-dd hh:mm"), new Uri(SampleUrl), TextHelper.LineBreak);

			var userGroupListResponse = await slackClient.UserGroups.ListAsync();
			var userGroup = userGroupListResponse.UserGroups.FirstOrDefault();
			if (userGroup != null)
			{
				var userGroupId = userGroup.Id;
				messageWithTextHelper = messageWithTextHelper
					.LineBreak()
					.Text($"User group mention by {nameof(TextHelper)}: {TextHelper.UserGroupMention(userGroupId)}");

				messageWithTextBuilder = messageWithTextBuilder.UserGroupMention(userGroupId, TextHelper.LineBreak);
			}

			var messageWithTextHelperResponse = await slackClient.Chat.PostMessageAsync(messageWithTextHelper);
			var messageWithTextBuilderResponse = await slackClient.Chat.PostMessageAsync(messageWithTextBuilder);

			 var messageWithBlocks = MessageBuilder.CreateBuilder(channelName)
				.Reply(messageWithTextBuilderResponse.Timestamp, true)
			 	.Blocks(CreateHeaderBlock())
			 	.Blocks(CreateActionBlock(), CreateContextBlock())
			 	.Attachments(new Attachment("#000099", "Attachment1"))
			 	.Attachments(new Attachment("#009900", "Attachment2"), new Attachment("#990000", "Attachment3"))
			 	.CreateMessage();
			
			 var messageWithBlocksResponse = await slackClient.Chat.PostMessageAsync(messageWithBlocks);

			return (messageWithTextHelperResponse, messageWithTextBuilderResponse, messageWithBlocksResponse);
		}

		public static Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync(SlackClient slackClient, string channelName, string userId)
		{
			var ephemeralMessage = new EphemeralMessage
			{
				ChannelIdOrName = channelName,
				UserId = userId,
				Text = $"{nameof(SendEphemeralMessageAsync)} method"
			};

			return slackClient.Chat.PostEphemeralAsync(ephemeralMessage);
		}
		
		public static async Task<DeletedMessageResponse> DeleteMessageAsync(SlackClient slackClient, string channelName)
		{
			var sendMessageResponse = await SendSimpleMessageAsync(slackClient, channelName, nameof(DeleteMessageAsync));

			return await slackClient.Chat.DeleteAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
		}

		public static Task<ScheduleMessageResponse> ScheduleMessageAsync(SlackClient slackClient, string channelName, int minutesToSchedule = 1)
		{
			const string DateTimeFormat = "dd MMMM yyyy HH:mm:ss tt";
			var now = DateTime.Now;
			var scheduledDateTime =now.AddMinutes(minutesToSchedule);
			
			var scheduledMessage = new MessageToSchedule
			{
				ChannelIdOrName = channelName,
				Text = $"Scheduled message\nNow dateTime - {now.ToString(DateTimeFormat)}\nScheduled dateTime - {scheduledDateTime.ToString(DateTimeFormat)}",
				PostAt = UnixTimeHelper.ToUnixTime(scheduledDateTime)
			};

			return slackClient.Chat.ScheduleMessageAsync(scheduledMessage);
		}
		
		public static async Task<ScheduledMessageListResponse> GetScheduledMessageListAsync(SlackClient slackClient, string channelName)
		{
			const int MinutesToSchedule = 2;
			await ScheduleMessageAsync(slackClient, channelName, MinutesToSchedule);
			var scheduleMessage2 = await ScheduleMessageAsync(slackClient, channelName, MinutesToSchedule);

			return await slackClient.Chat.ScheduledMessagesListAsync(scheduleMessage2?.ChannelId);
		}
		
		public static async Task<SlackBaseResponse> DeleteScheduledMessageAsync(SlackClient slackClient, string channelName)
		{
			var scheduleMessageResponse = await ScheduleMessageAsync(slackClient, channelName, 2);

			return await slackClient.Chat.DeleteScheduledMessageAsync(scheduleMessageResponse.ChannelId, scheduleMessageResponse.ScheduledMessageId);
		}
		
		public static async Task<MessagePermalinkResponse> GetMessagePermalinkAsync(SlackClient slackClient, string channelName)
		{
			var sendMessageResponse = await SendSimpleMessageAsync(slackClient, channelName, nameof(GetMessagePermalinkAsync));

			return await slackClient.Chat.GetPermalinkAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
		}
		
		public static async Task<UpdateMessageResponse> UpdateMessageAsync(SlackClient slackClient, string channelName)
		{
			var sendMessageResponse = await SendSimpleMessageAsync(slackClient, channelName, nameof(UpdateMessageAsync));
			
			return await slackClient.Chat.UpdateAsync(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, "UpdatedText");
		}

		public static Task<SendMessageResponse> SendSimpleMessageAsync(
			SlackClient slackClient,
			string channelIdOrName,
			string nameOfMethod,
			string threadTimestamp = null)
		{
			var message = new SlackMessage
			{
				ChannelIdOrName = channelIdOrName,
				Text = $"{nameOfMethod} method",
				ThreadTimestamp = threadTimestamp
			};

			return slackClient.Chat.PostMessageAsync(message);
		}

		private static List<BlockBase> GenerateBlocks()
		{
			var blocks = new List<BlockBase>
			{
				CreateActionBlock(),
				CreateContextBlock(),
				new DividerBlock(),
				CreateHeaderBlock(),
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
					Fields = new List<TextObjectBase>
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

		private static ContextBlock CreateContextBlock()
			=> new ContextBlock
			{
				Elements = new List<IContextElement>
				{
					(PlainTextObject)"This is Context Block",
					new ImageElement
					{
						AltText = "Kitty in the Context block",
						ImageUrl = new Uri("https://unsplash.com/photos/fZ8uf_L52wg/download?force=true&w=640"),
					},
				},
			};

		private static ActionBlock CreateActionBlock()
			=> new ActionBlock
			{
				Elements = new List<IActionElement>
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
			};

		private static HeaderBlock CreateHeaderBlock()
			=> new HeaderBlock
			{
				Text = "This is Header Block",
			};
	}
}