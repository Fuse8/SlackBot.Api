using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models;
using SlackBot.Api.Models.Bot.Info.Request;
using SlackBot.Api.Models.Bot.Info.Response;
using SlackBot.Api.Models.Chat.Delete.Request;
using SlackBot.Api.Models.Chat.Delete.Response;
using SlackBot.Api.Models.Chat.DeleteScheduledMessage.Request;
using SlackBot.Api.Models.Chat.GetPermalink.Request;
using SlackBot.Api.Models.Chat.GetPermalink.Response;
using SlackBot.Api.Models.Chat.PostEphemeral.Request;
using SlackBot.Api.Models.Chat.PostEphemeral.Response;
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
using SlackBot.Api.Models.Chat.Update.Request;
using SlackBot.Api.Models.Chat.Update.Response;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.File.Delete.Request;
using SlackBot.Api.Models.File.Info.Request;
using SlackBot.Api.Models.File.Info.Response;
using SlackBot.Api.Models.File.List.Request;
using SlackBot.Api.Models.File.List.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.File.Upload.Response;
using SlackBot.Api.Models.Pin.Add.Request;
using SlackBot.Api.Models.Pin.List.Request;
using SlackBot.Api.Models.Pin.List.Response;
using SlackBot.Api.Models.Pin.Remove.Request;
using SlackBot.Api.Models.Reaction.Add.Request;
using SlackBot.Api.Models.Reaction.Get.Request;
using SlackBot.Api.Models.Reaction.Get.Response;
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
		private static readonly SlackClient _slackClient;
		
		static Program()
		{
			var configuration = GetConfiguration();
			_slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");
			_slackClient = SlackClientFactory.CreateSlackClient(_slackBotSettings.Token);
		}

		// ReSharper disable once InconsistentNaming
		public static async Task Main(string[] args)
		{

			/* Sends message with some blocks * /
			var postMessageResponse = await SendMessageWithBlocksAsync(); /**/

			/* Uploads some files and sends message with them * /
			var postMessageWithFilesResponse = await SendMessageWithMultipleFilesAsync(); /**/

			/* Sends ephemeral message * /
			var postMessageWithFilesResponse = await SendEphemeralMessageAsync(); /**/

			/* Deletes message * /
			var deletedMessageResponse = await DeleteMessageAsync(); /**/
			
			/* Schedules message to channel * /
			var scheduleMessageResponse = await ScheduleMessageAsync(); /**/
			
			/* Gets list of scheduled messages * /
			var scheduledMessageListResponse = await GetScheduledMessagesAsync(); /**/
			
			/* Deletes scheduled message * /
			var deleteScheduledMessageResponse = await DeleteScheduledMessageAsync(); /**/

			/* Gets message permalink * /
			var messagePermalinkResponse = await GetMessagePermalinkAsync(); /**/
			
			/* Updates message * /
			var updateMessageResponse = await UpdateMessageAsync(); /**/
			
			/* Gets bot info * /
			var botInfoResponse = await GetBotInfoAsync(); /**/

			/* Uploads plain file content * /
			var uploadContentResponse = await UploadContentAsync(); /**/
 
			/* Uploads file from disk * /
			var uploadFileResponse = await UploadFileAsync(); /**/
 
			/* Deletes file * /
			var deleteFileResponse = await DeleteFileAsync(); /**/
 
			/* Gets file info * /
			var fileInfoResponse = await GetFileInfoAsync(); /**/
 
			/* Gets file list * /
			var fileListResponse = await GetFileListAsync(); /**/
 
			/* Pins message * /
			var pinMessageResponse = await PinMessageAsync(); /**/
 
			/* Get pinned items * /
			var pinListResponse = await GetPinListAsync(); /**/
 
			/* Removes pinned item * /
			var removePinResponse = await RemovePinAsync(); /**/
 
			/* Adds reaction * /
			var addReactionResponse = await AddReactionAsync(); /**/
 
			/* Gets reactions * /
			var getReactionsResponse = await GetReactionsAsync(); /**/

            /* Gets list of bot channels * /
			var userConversationsResponse = await GetUserConversationsAsync();/**/
            
            /* Gets conversation's history of messages and events * /
			var conversationsHistoryResponse = await GetConversationsHistoryAsync();/**/
		}

		private static Task<SendMessageResponse> SendMessageWithBlocksAsync()
		{
			var blocks = GenerateBlocksForMessage();

			var message = new Message
			{
				ChannelIdOrName = _slackBotSettings.ChannelName,
				Blocks = blocks,
				Text = "SendMessageWithBlocksAsync method",
				Attachments = new[]
				{
					new Attachment
					{
						Color = "#36a64f",
						Blocks = blocks,
					},
				},
			};

			return _slackClient.SendMessageAsync(message);
		}

		private static async Task<SendMessageResponse> SendMessageWithMultipleFilesAsync()
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

			var firstFile = await _slackClient.UploadContentAsync(contentMessage);

			contentMessage.Title = "File2";
			var secondFile = await _slackClient.UploadContentAsync(contentMessage);

			var message = new Message
			{
				ChannelIdOrName = _slackBotSettings.ChannelName,
				Text = firstFile.File.Permalink + " " + secondFile.File.Permalink,
				Blocks = new BlockBase[]
				{
					new ContextBlock
					{
						Elements = new IContextElement[]
						{
							(PlainTextObject)"SendMessageWithMultipleFilesAsync method",
						},
					},
				},
			};

			return await _slackClient.SendMessageAsync(message);
		}

		private static Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync()
		{
			var ephemeralMessage = new EphemeralMessage(_slackBotSettings.ChannelName, _slackBotSettings.UserId, "SendEphemeralMessageAsync method");

			return _slackClient.SendEphemeralMessageAsync(ephemeralMessage);
		}
		
		private static async Task<DeletedMessageResponse> DeleteMessageAsync()
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(DeleteMessageAsync));

			var messageToDelete = new MessageToDelete
			{
				ChannelId = sendMessageResponse.ChannelId,
				MessageTimestamp = sendMessageResponse.Timestamp
			};

			return await _slackClient.DeleteMessageAsync(messageToDelete);
		}

		private static Task<ScheduleMessageResponse> ScheduleMessageAsync(int minutesToSchedule = 1)
		{
			const string DateTimeFormat = "dd MMMM yyyy HH:mm:ss tt";
			var now = DateTime.Now;
			var scheduledDateTime =now.AddMinutes(minutesToSchedule);
			
			var scheduledMessage = new MessageToSchedule
			{
				ChannelIdOrName = _slackBotSettings.ChannelName,
				Text = $"Scheduled message\nNow dateTime - {now.ToString(DateTimeFormat)}\nScheduled dateTime - {scheduledDateTime.ToString(DateTimeFormat)}",
				PostAt = UnixTimeHelper.ToUnixTime(scheduledDateTime)
			};

			return _slackClient.ScheduleMessageAsync(scheduledMessage);
		}
		
		private static async Task<ScheduledMessageListResponse> GetScheduledMessagesAsync()
		{
			const int MinutesToSchedule = 2;
			var scheduleMessage1 = await ScheduleMessageAsync(MinutesToSchedule);
			var scheduleMessage2 = await ScheduleMessageAsync(MinutesToSchedule);

			var scheduledMessageListRequest = new ScheduledMessageListRequest
			{
				ChannelId = scheduleMessage2?.ChannelId
			};

			return await _slackClient.GetScheduledMessages(scheduledMessageListRequest);
		}
		
		private static async Task<SlackBaseResponse> DeleteScheduledMessageAsync()
		{
			var scheduleMessageResponse = await ScheduleMessageAsync(2);
			
			var scheduledMessageToDelete = new ScheduledMessageToDelete
			{
				Channel = scheduleMessageResponse.ChannelId,
				ScheduledMessageId = scheduleMessageResponse.ScheduledMessageId
			};

			return await _slackClient.DeleteScheduledMessageAsync(scheduledMessageToDelete);
		}
		
		private static async Task<MessagePermalinkResponse> GetMessagePermalinkAsync()
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(GetMessagePermalinkAsync));

			var messagePermalinkRequest = new MessagePermalinkRequest(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);

			return await _slackClient.GetMessagePermalinkAsync(messagePermalinkRequest);
		}
		
		private static async Task<UpdateMessageResponse> UpdateMessageAsync()
		{
			var message = new Message(_slackBotSettings.ChannelName, "Not updated text");
			var sendMessageResponse = await _slackClient.SendMessageAsync(message);

			var messageToUpdate = new MessageToUpdate(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, "UpdatedText");
			
			return await _slackClient.UpdateMessage(messageToUpdate);
		}
		
		private static async Task<BotInfoResponse> GetBotInfoAsync()
		{
			var message = new Message(_slackBotSettings.ChannelName, "GetBotInfo method");
			var sendMessageResponse = await _slackClient.SendMessageAsync(message);

			var botInfoRequest = new BotInfoRequest(sendMessageResponse.Message.BotId);
			
			return await _slackClient.GetBotInfoAsync(botInfoRequest);
		}

		// ReSharper disable once UnusedMethodReturnValue.Local
		private static async Task<UploadFileResponse> UploadContentAsync()
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			var contentMessage = new ContentToUpload
			{
				Comment = "UploadContentAsync method",
				Title = "Title",
				Channels = _slackBotSettings.ChannelName,
				Content = content,
				Filename = "appsettings.json",
				FileType = "javascript",
			};

			return await _slackClient.UploadContentAsync(contentMessage);
		}

		private static async Task<UploadFileResponse> UploadFileAsync()
		{
			await using var fileStream = File.Open("./appsettings.json", FileMode.Open);
			var fileMessage = new FileToUpload
			{
				Channels = _slackBotSettings.ChannelName,
				Stream = fileStream,
				Comment = "UploadFileAsync method"
			};

			return await _slackClient.UploadFileAsync(fileMessage);
		}

		private static async Task<SlackBaseResponse> DeleteFileAsync()
		{
			var uploadFileResponse = await UploadFileAsync();
			
			var fileToDelete = new FileToDelete(uploadFileResponse.File.Id);

			return await _slackClient.DeleteFileAsync(fileToDelete);
		}

		private static async Task<FileInfoResponse> GetFileInfoAsync()
		{
			var uploadFileResponse = await UploadFileAsync();
			
			var fileInfoRequest = new FileInfoRequest(uploadFileResponse.File.Id);

			return await _slackClient.GetFileInfoAsync(fileInfoRequest);
		}

		private static async Task<FileListResponse> GetFileListAsync()
		{
			var uploadFileResponse = await UploadFileAsync();
			await UploadContentAsync();

			// Because of slack cache... Files upload instantly, but they attach to group delayed
			await Task.Delay(30000);
			
			var firstFile = uploadFileResponse.File;
			var fileListRequest = new FileListRequest
			{
				ChannelId = firstFile.ChannelIds.FirstOrDefault() ?? firstFile.GroupIds.FirstOrDefault(),
				TimestampFrom = firstFile.CreatedTimestamp.ToString(),
			};

			return await _slackClient.GetFileListAsync(fileListRequest);
		}

		private static async Task<SlackBaseResponse> PinMessageAsync()
		{
			var (pinResponse, _) = await PinMessageInternalAsync();

			return pinResponse;
		}
		
		private static async Task<PinListResponse> GetPinListAsync()
		{
			var (_, sendMessageResponse) = await PinMessageInternalAsync();
			await PinMessageInternalAsync();

			var pinListRequest = new PinListRequest(sendMessageResponse.ChannelId);

			return await _slackClient.GetPinListAsync(pinListRequest);
		}

		private static async Task<SlackBaseResponse> RemovePinAsync()
		{
			var (_, sendMessageResponse) = await PinMessageInternalAsync();
			
			var removePinRequest = new PinItemToRemove(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);

			return await _slackClient.RemovePinAsync(removePinRequest);
		}

		private static async Task<SlackBaseResponse> AddReactionAsync()
		{
			var (addReactionResponse, _) = await AddReactionInternalAsync();

			return addReactionResponse;
		}
		
		private static async Task<SlackBaseResponse> GetReactionsAsync()
		{
			var (_, sendMessageResponse) = await AddReactionInternalAsync();
			await AddReactionToMessageAsync(sendMessageResponse, "smile");
			
			var getReactionsRequest = new GetReactionsRequest(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);

			return await _slackClient.GetReactionsAsync(getReactionsRequest);
		}

		private static Task<UserConversationsResponse> GetUserConversationsAsync()
		{
			var userConversations = new UserConversations
			{
				Types = "public_channel,private_channel,mpim,im",
			};

			return _slackClient.UserConversationsAsync(userConversations);
        }
        
        private static async Task<ConversationsHistoryResponse> GetConversationsHistoryAsync()
        {
	        var channelId = await GetChannelIdAsync();

	        var conversationsHistory = new ConversationsHistory(channelId, 1000);

	        return await _slackClient.ConversationsHistoryAsync(conversationsHistory);
        }
        
		private static Task<SendMessageResponse> SendSimpleMessageAsync(string nameOfMethod)
		{
			var message = new Message
			{
				ChannelIdOrName = _slackBotSettings.ChannelName,
				Text = $"{nameOfMethod} method",
			};

			return _slackClient.SendMessageAsync(message);
		}
		
        private static async Task<string> GetChannelIdAsync()
        {
	        var userConversations = new UserConversations
	        {
		        Types = "public_channel,private_channel,mpim,im"
	        };

	        var conversationsHistoryResponse = await _slackClient.UserConversationsAsync(userConversations);
	        var channelId = conversationsHistoryResponse?.Channels?.FirstOrDefault(p => p.Name == _slackBotSettings.ChannelName)?.Id;

	        return channelId;
		}

		private static async Task<(SlackBaseResponse PinResponse, SendMessageResponse SendMessageResponse)> PinMessageInternalAsync()
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(PinMessageInternalAsync));

			var pinItem = new PinItem(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
			var pinMessageResponse = await _slackClient.PinMessageAsync(pinItem);

			return (pinMessageResponse, sendMessageResponse);
		}

		private static async Task<(SlackBaseResponse AddReactionResponse, SendMessageResponse SendMessageResponse)> AddReactionInternalAsync(
			string emojiName = "+1")
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(AddReactionAsync));

			var addReactionResponse = await AddReactionToMessageAsync(sendMessageResponse, emojiName);

			return (addReactionResponse, sendMessageResponse);
		}

		private static Task<SlackBaseResponse> AddReactionToMessageAsync(SendMessageResponse sendMessageResponse, string emojiName)
		{
			var reaction = new Reaction(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, emojiName);
			
			return _slackClient.AddReactionAsync(reaction);
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