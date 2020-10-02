using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SlackBot.Api;
using SlackBot.Api.Helpers;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class ChatClientMethods
	{
		public static Task<SendMessageResponse> SendMessageWithBlocksAsync(SlackClient slackClient, string channelName)
		{
			var blocks = GenerateBlocksForMessage();

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
			string channelName,
			string nameOfMethod,
			string channelId = null,
			string threadTimestamp = null)
		{
			var message = new SlackMessage
			{
				ChannelIdOrName = channelId ?? channelName,
				Text = $"{nameOfMethod} method",
				ThreadTimestamp = threadTimestamp
			};

			return slackClient.Chat.PostMessageAsync(message);
		}

		public static List<BlockBase> GenerateBlocksForMessage()
		{
			var blocks = new List<BlockBase>
			{
				new ActionBlock
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
				},
				new ContextBlock
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
	}
}