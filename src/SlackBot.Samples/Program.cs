﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SlackBot.Api;
using SlackBot.Api.Exceptions;
using SlackBot.Api.Extensions;
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
using SlackBot.Api.Models.Conversation;
using SlackBot.Api.Models.Conversation.Archive.Request;
using SlackBot.Api.Models.Conversation.Close.Request;
using SlackBot.Api.Models.Conversation.Close.Response;
using SlackBot.Api.Models.Conversation.Create.Request;
using SlackBot.Api.Models.Conversation.History.Request;
using SlackBot.Api.Models.Conversation.History.Response;
using SlackBot.Api.Models.Conversation.Info.Request;
using SlackBot.Api.Models.Conversation.Invite.Request;
using SlackBot.Api.Models.Conversation.Join.Request;
using SlackBot.Api.Models.Conversation.Kick.Request;
using SlackBot.Api.Models.Conversation.Leave.Request;
using SlackBot.Api.Models.Conversation.Leave.Response;
using SlackBot.Api.Models.Conversation.List.Request;
using SlackBot.Api.Models.Conversation.Members.Request;
using SlackBot.Api.Models.Conversation.Members.Response;
using SlackBot.Api.Models.Conversation.Open.Request;
using SlackBot.Api.Models.Conversation.Open.Response;
using SlackBot.Api.Models.Conversation.Rename.Request;
using SlackBot.Api.Models.Conversation.Replies.Request;
using SlackBot.Api.Models.Conversation.Replies.Response;
using SlackBot.Api.Models.Conversation.SetPurpose.Request;
using SlackBot.Api.Models.Conversation.SetTopic.Request;
using SlackBot.Api.Models.Conversation.Unarchive.Request;
using SlackBot.Api.Models.Emoji.List.Response;
using SlackBot.Api.Models.File.Delete.Request;
using SlackBot.Api.Models.File.Info.Request;
using SlackBot.Api.Models.File.Info.Response;
using SlackBot.Api.Models.File.List.Request;
using SlackBot.Api.Models.File.List.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.FileRemote.Add.Request;
using SlackBot.Api.Models.FileRemote.Info.Request;
using SlackBot.Api.Models.FileRemote.List.Request;
using SlackBot.Api.Models.FileRemote.List.Response;
using SlackBot.Api.Models.FileRemote.Remove.Request;
using SlackBot.Api.Models.FileRemote.Share.Request;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.File;
using SlackBot.Api.Models.Pin.Add.Request;
using SlackBot.Api.Models.Pin.List.Request;
using SlackBot.Api.Models.Pin.List.Response;
using SlackBot.Api.Models.Pin.Remove.Request;
using SlackBot.Api.Models.Reaction.Add.Request;
using SlackBot.Api.Models.Reaction.Get.Request;
using SlackBot.Api.Models.Reaction.Get.Response;
using SlackBot.Api.Models.Reaction.List.Request;
using SlackBot.Api.Models.Reaction.List.Response;
using SlackBot.Api.Models.Reaction.Remove.Request;
using SlackBot.Api.Models.TeamProfile.Get.Request;
using SlackBot.Api.Models.TeamProfile.Get.Response;
using SlackBot.Api.Models.User;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.GetPresence.Request;
using SlackBot.Api.Models.User.GetPresence.Response;
using SlackBot.Api.Models.User.Info.Request;
using SlackBot.Api.Models.User.List.Request;
using SlackBot.Api.Models.User.List.Response;
using SlackBot.Api.Models.User.LookupByEmail.Request;
using SlackBot.Api.Models.User.SetPresence.Request;
using SlackBot.Samples.Configurations;
using SlackBot.Samples.Extensions;

#region disable formatting rules
	
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedVariable
// ReSharper disable UnusedMethodReturnValue.Local
#pragma warning disable 1998

#endregion

namespace SlackBot.Samples
{
	public class Program
	{
		private static readonly SlackBotSettings _slackBotSettings;
		private static readonly SlackClient _slackClient;

		private const string NewChannelName = "some-new-channel";
		
		static Program()
		{
			var configuration = GetConfiguration();
			_slackBotSettings = configuration.GetSection<SlackBotSettings>("SlackBotSettings");
			_slackClient = SlackClientFactory.CreateSlackClient(_slackBotSettings.Token);
		}

		// ReSharper disable once InconsistentNaming
		public static async Task Main()
		{
			/* Gets bot info * /
			var botInfoResponse = await GetBotInfoAsync(); /**/
			
			/* Gets custom emoji list for team * /
			var emojiListResponse = await GetEmojiListAsync(); /**/

			#region File methods

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
			
			#endregion

			#region FileRemote methods
 
			/* Adds remote file * /
			var remoteFileResponse = await AddRemoteFileAsync(); /**/
 
			/* Gets remote file info * /
			var getRemoteFileInfoResponse = await GetRemoteFileInfoAsync(); /**/
 
			/* Gets remote file list * /
			var getRemoteFileListResponse = await GetRemoteFileListAsync(); /**/
 
			/* Removes remote file * /
			var removeRemoteFileResponse = await RemoveRemoteFileAsync(); /**/
 
			/* Shares remote file * /
			var shareRemoteFileResponse = await ShareRemoteFileAsync(); /**/

			#endregion

			#region Chat methods
			
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
			
			#endregion

			#region Conversation methods
            
            /* Archives conversation * /
			var archiveConversationResponse = await ArchiveConversationAsync();/**/
            
            /* Archives conversation * /
			var closeConversationResponse = await CloseConversationAsync();/**/
            
            /* Creates channel * /
			var createChannelResponse = await CreateChannelAsync();/**/
            
            /* Gets conversation's history of messages and events * /
			var conversationsHistoryResponse = await GetConversationsHistoryAsync();/**/
            
            /* Gets information about conversation * /
			var conversationInfoResponse = await GetConversationInfoAsync();/**/
            
            /* Creates channel and invites user * /
			var inviteToConversationResponse = await InviteToConversationAsync();/**/
            
            /* Joins to conversation * /
			var joinToConversationResponse = await JoinToConversationAsync();/**/
            
            /* Kicks from conversation * /
			var kickFromConversationResponse = await KickFromConversationAsync();/**/
            
            /* Leaves conversation * /
			var leaveConversationResponse = await LeaveConversationAsync();/**/
            
            /* Gets conversation list * /
			var getConversationListResponse = await GetConversationListAsync();/**/
            
            /* Gets conversation's members * /
			var getConversationMembersResponse = await GetConversationMembersAsync();/**/
            
            /* Opens conversation * /
			var openConversationResponse = await OpenConversationAsync();/**/
            
            /* Renames conversation * /
			var renameConversationResponse = await RenameConversationAsync();/**/
            
            /* Gets message replies from conversation * /
			var getConversationRepliesResponse = await GetConversationRepliesAsync();/**/
            
            /* Sets conversation purpose * /
			var setConversationPurposeResponse = await SetConversationPurposeAsync();/**/
            
            /* Sets conversation purpose * /
			var setConversationTopicResponse = await SetConversationTopicAsync();/**/
            
            /* Unarchives conversation * /
			var unarchiveConversationResponse = await UnarchiveConversationAsync();/**/

			#endregion

			#region Pin methods
			
			/* Pins message * /
			var pinMessageResponse = await PinMessageAsync(); /**/
 
			/* Get pinned items * /
			var pinListResponse = await GetPinListAsync(); /**/
 
			/* Removes pinned item * /
			var removePinResponse = await RemovePinAsync(); /**/
			
			#endregion

			#region Reaction methods

			/* Adds reaction * /
			var addReactionResponse = await AddReactionAsync(); /**/
 
			/* Gets reactions by item* /
			var reactionsByItemResponse = await GetReactionsByItemAsync(); /**/
 
			/* Gets reactions by user* /
			var reactionsByUserResponse = await GetReactionsByUserAsync(); /**/

            /* Removes reaction * /
			var removeReactionResponse = await RemoveReactionAsync();/**/
			
			#endregion
            
			/* Gets team profile * /
			var teamProfileResponse = await GetTeamProfileAsync();/**/

			#region User methods

            /* Gets list of user channels * /
			var userConversationsResponse = await GetUserConversationsAsync();/**/

			/* Gets user presence information * /
			var userPresenceResponse = await GetUserPresenceAsync();/**/

            /* Gets information about user * /
			var userInfoResponse = await GetUserInfoAsync();/**/

            /* Gets list of all users * /
			var userListResponse = await GetUserListAsync();/**/

            /* Gets user by email * /
			var userByEmailResponse = await GetUserByEmailAsync();/**/

            /* Sets user presence * /
			var setUserPresenceResponse = await SetUserPresenceAsync();/**/
			
			#endregion
		}

		#region Bot

		private static async Task<BotInfoResponse> GetBotInfoAsync()
		{
			var message = new Message(_slackBotSettings.ChannelName, $"{nameof(GetBotInfoAsync)} method");
			var sendMessageResponse = await _slackClient.SendMessageAsync(message);
			
			return await _slackClient.GetBotInfoAsync(new BotInfoRequest(sendMessageResponse.Message.BotId));
		}
		
		#endregion

		#region Emoji

		private static async Task<EmojiListResponse> GetEmojiListAsync()
			=> await _slackClient.EmojiListAsync();

		#endregion

		#region File
		
		private static async Task<SlackFileResponse> UploadContentAsync()
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			var contentMessage = new ContentToUpload
			{
				Comment = $"{nameof(UploadContentAsync)} method",
				Title = "Title",
				Channels = _slackBotSettings.ChannelName,
				Content = content,
				Filename = "appsettings.json",
				FileType = "javascript",
			};

			return await _slackClient.UploadContentAsync(contentMessage);
		}

		private static async Task<SlackFileResponse> UploadFileAsync()
		{
			await using var fileStream = File.Open("./appsettings.json", FileMode.Open);
			var fileMessage = new FileToUpload
			{
				Channels = _slackBotSettings.ChannelName,
				Stream = fileStream,
				Comment = $"{nameof(UploadFileAsync)} method"
			};

			return await _slackClient.UploadFileAsync(fileMessage);
		}

		private static async Task<SlackBaseResponse> DeleteFileAsync()
		{
			var uploadFileResponse = await UploadFileAsync();
			
			return await _slackClient.DeleteFileAsync(new FileToDelete(uploadFileResponse.File.Id));
		}

		private static async Task<FileInfoResponse> GetFileInfoAsync()
		{
			var uploadFileResponse = await UploadFileAsync();
			
			return await _slackClient.GetFileInfoAsync(new FileInfoRequest(uploadFileResponse.File.Id));
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
		
		#endregion

		#region RemoteFile

		private static Task<SlackFileResponse> AddRemoteFileAsync()
		{
			var remoteFile = new RemoteFile
			{
				ExternalId = Guid.NewGuid().ToString(),
				ExternalUrl = new Uri("https://unsplash.com/photos/Dl39g6QhOIM"),
				Title = "Beautiful cat",
				FileType = "jpg",
			};

			return _slackClient.AddRemoteFileAsync(remoteFile);
		}

		private static async Task<SlackFileResponse> GetRemoteFileInfoAsync()
		{
			var addRemoteFileResponse = await AddRemoteFileAsync();

			return await _slackClient.RemoteFileInfoAsync(new RemoteFileInfoRequest(addRemoteFileResponse.File.Id));
		}

		private static async Task<RemoteFileListResponse> GetRemoteFileListAsync()
		{
			await AddRemoteFileAsync();
			
			// Because of slack cache... Files upload instantly, but they return in method "files.remote.list" with delay
			await Task.Delay(30000);

			return await _slackClient.RemoteFileListAsync(new RemoteFileListRequest());
		}

		private static async Task<SlackBaseResponse> RemoveRemoteFileAsync()
		{
			var addRemoteFileResponse = await AddRemoteFileAsync();

			return await _slackClient.RemoveRemoteFileAsync(new RemoteFileToRemove(addRemoteFileResponse.File.Id));
		}

		private static async Task<SlackBaseResponse> ShareRemoteFileAsync()
		{
			var addRemoteFileResponse = await AddRemoteFileAsync();
			
			var channelId = await GetChannelIdAsync();

			return await _slackClient.ShareRemoteFileAsync(new RemoteFileToShare(channelId, addRemoteFileResponse.File.Id));
		}

		#endregion

		#region Chat

		private static Task<SendMessageResponse> SendMessageWithBlocksAsync()
		{
			var blocks = GenerateBlocksForMessage();

			var message = new Message
			{
				ChannelIdOrName = _slackBotSettings.ChannelName,
				Blocks = blocks,
				Text = $"{nameof(SendMessageWithBlocksAsync)} method",
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
							(PlainTextObject)$"{nameof(SendMessageWithMultipleFilesAsync)} method",
						},
					},
				},
			};

			return await _slackClient.SendMessageAsync(message);
		}

		private static Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync()
		{
			var ephemeralMessage = new EphemeralMessage
			{
				ChannelIdOrName = _slackBotSettings.ChannelName,
				UserId = _slackBotSettings.UserId,
				Text = $"{nameof(SendEphemeralMessageAsync)} method"
			};

			return _slackClient.SendEphemeralMessageAsync(ephemeralMessage);
		}
		
		private static async Task<DeletedMessageResponse> DeleteMessageAsync()
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(DeleteMessageAsync));

			return await _slackClient.DeleteMessageAsync(new MessageToDelete(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp));
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

			return await _slackClient.GetScheduledMessagesAsync(new ScheduledMessageListRequest(scheduleMessage2?.ChannelId));
		}
		
		private static async Task<SlackBaseResponse> DeleteScheduledMessageAsync()
		{
			var scheduleMessageResponse = await ScheduleMessageAsync(2);

			return await _slackClient.DeleteScheduledMessageAsync(new ScheduledMessageToDelete(scheduleMessageResponse.ChannelId, scheduleMessageResponse.ScheduledMessageId));
		}
		
		private static async Task<MessagePermalinkResponse> GetMessagePermalinkAsync()
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(GetMessagePermalinkAsync));

			return await _slackClient.GetMessagePermalinkAsync(new MessagePermalinkRequest(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp));
		}
		
		private static async Task<UpdateMessageResponse> UpdateMessageAsync()
		{
			var message = new Message(_slackBotSettings.ChannelName, "Not updated text");
			var sendMessageResponse = await _slackClient.SendMessageAsync(message);
			
			return await _slackClient.UpdateMessageAsync(new MessageToUpdate(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, "UpdatedText"));
		}
        
		private static Task<SendMessageResponse> SendSimpleMessageAsync(string nameOfMethod, string channelId = null, string threadTimestamp = null)
		{
			var message = new Message
			{
				ChannelIdOrName = channelId ?? _slackBotSettings.ChannelName,
				Text = $"{nameOfMethod} method",
				ThreadTimestamp = threadTimestamp
			};

			return _slackClient.SendMessageAsync(message);
		}
		
		#endregion

		#region Conversation

		private static async Task<SlackBaseResponse> ArchiveConversationAsync(string conversationId = null)
        {
	        var channelId = conversationId ?? await GetChannelIdAsync();

	        return await _slackClient.ArchiveConversationAsync(new ConversationToArchive(channelId));
        }

		private static async Task<ClosedConversationResponse> CloseConversationAsync()
		{
			var openConversationResponse = await OpenConversationAsync();
			
			return await _slackClient.CloseConversationAsync(new ConversationToClose(openConversationResponse.Channel.Id));
		}

		private static async Task<ConversationResponse> CreateChannelAsync()
		{
			var (createChannelResponse, _) = await CreateChannelAndInviteAsync();

			return createChannelResponse;
		}

		private static async Task<ConversationsHistoryResponse> GetConversationsHistoryAsync()
        {
	        var channelId = await GetChannelIdAsync();

	        return await _slackClient.ConversationsHistoryAsync(new ConversationsHistory(channelId, 1000));
        }

		private static async Task<ConversationResponse> GetConversationInfoAsync()
        {
	        var channelId = await GetChannelIdAsync();

	        return await _slackClient.ConversationInfoAsync(new ConversationToGetInfo(channelId, true, true));
        }

		private static async Task<ConversationResponse> InviteToConversationAsync()
        {
			var (_, inviteToConversationResponse) = await CreateChannelAndInviteAsync();

			return inviteToConversationResponse;
        }

		private static async Task<ConversationResponse> JoinToConversationAsync()
        {
			var (channelId, _) = await TryCreateChannelAsync();

			return await _slackClient.JoinToConversationAsync(new ConversationToJoin(channelId));
        }

		private static async Task<SlackBaseResponse> KickFromConversationAsync()
        {
			var (channelId, _) = await TryCreateChannelAsync();
			
			var userId = _slackBotSettings.UserId;
			await TryInviteToConversationAsync(channelId, userId);

			return await _slackClient.KickFromConversationAsync(new KickFromConversationRequest(channelId, userId)); // TODO returns error "restricted_action" 
        }

		private static async Task<LeaveConversationResponse> LeaveConversationAsync()
        {
			var channelId = await GetChannelIdAsync();

			return await _slackClient.LeaveConversationAsync(new ConversationToLeave(channelId));
        }

		private static async Task<ConversationListResponse> GetConversationListAsync()
			=> await _slackClient.ConversationListAsync(new ConversationListRequest("public_channel,private_channel,mpim,im", limit: 1000));

		private static async Task<ConversationMembersResponse> GetConversationMembersAsync()
		{
			var channelId = await GetChannelIdAsync();
			
			return await _slackClient.ConversationMembersAsync(new ConversationMembersRequest(channelId));
		}

		private static async Task<OpenedConversationResponse> OpenConversationAsync()
        {
			var openedConversationResponse = await _slackClient.OpenConversationAsync(new ConversationToOpen(_slackBotSettings.UserId, true));
			
			await SendSimpleMessageAsync(nameof(OpenConversationAsync), openedConversationResponse.Channel.Id);

			return openedConversationResponse;
		}

		private static async Task<ConversationResponse> RenameConversationAsync()
		{
			var (channelId, channelName) = await TryCreateChannelAsync();

			var renameConversationResponse = await _slackClient.RenameConversationAsync(new ConversationToRename(channelId, $"{channelName}-new-name"));
			
			await _slackClient.RenameConversationAsync(new ConversationToRename(channelId, channelName));

			return renameConversationResponse;
		}

		private static async Task<ConversationRepliesResponse> GetConversationRepliesAsync()
		{
			var channelId = await GetChannelIdAsync();

			var parentMessage = await SendSimpleMessageAsync(nameof(GetConversationRepliesAsync), channelId);

			var parentMessageTimestamp = parentMessage.Timestamp;
			await SendSimpleMessageAsync(nameof(GetConversationRepliesAsync), channelId, parentMessageTimestamp);
			await SendSimpleMessageAsync(nameof(GetConversationRepliesAsync), channelId, parentMessageTimestamp);

			return await _slackClient.ConversationRepliesAsync(new ConversationRepliesRequest(channelId, parentMessageTimestamp));
		}

		private static async Task<ConversationResponse> SetConversationPurposeAsync()
		{
			var channelId = await GetChannelIdAsync();

			return await _slackClient.SetConversationPurposeAsync(new ConversationPurposeRequest(channelId, "new purpose"));
		}

		private static async Task<ConversationResponse> SetConversationTopicAsync()
		{
			var channelId = await GetChannelIdAsync();

			return await _slackClient.SetConversationTopicAsync(new ConversationTopicRequest(channelId, "new topic"));
		}

		private static async Task<SlackBaseResponse> UnarchiveConversationAsync()
        {
	        var channelId = await GetChannelIdAsync();

			await ArchiveConversationAsync(channelId);

			return await _slackClient.UnarchiveConversationAsync(new ConversationToUnarchive(channelId));
        }

		private static async Task<(string ChannelId, string ChannelName)> TryCreateChannelAsync()
		{
			string channelId;
			const string ChannelName = NewChannelName;

			try
			{
				var createChannelResponse = await _slackClient.CreateChannelAsync(new ChannelToCreate(ChannelName));
				channelId = createChannelResponse.Channel.Id;
			}
			catch (SlackApiResponseException e) when (e.Error == "name_taken")
			{
				channelId = await GetChannelIdAsync(ChannelName);
			}

			return (channelId, ChannelName);
		}

		private static async Task<(ConversationResponse CreateChannelResponse, ConversationResponse InviteToConversationResponse)> CreateChannelAndInviteAsync()
		{
			var createChannelResponse = await _slackClient.CreateChannelAsync(new ChannelToCreate(NewChannelName));

			var inviteToConversationResponse = await InviteToConversationInternalAsync(createChannelResponse.Channel.Id, _slackBotSettings.UserId);

			return (createChannelResponse, inviteToConversationResponse);
		}

		private static async Task TryInviteToConversationAsync(string channelId, string userIds)
		{
			try
			{
				await InviteToConversationInternalAsync(channelId, userIds);
			}
			catch (SlackApiResponseException e) when (e.Error == "already_in_channel")
			{
			}
		}

		private static Task<ConversationResponse> InviteToConversationInternalAsync(string channelId, string userIds)
			=> _slackClient.InviteToConversationAsync(new ConversationToInvite(channelId, userIds));

		private static async Task<string> GetChannelIdAsync(string channelName = null)
        {
			var conversationsHistoryResponse = await GetConversationListAsync();
			
			channelName ??= _slackBotSettings.ChannelName;
	        var channelId = conversationsHistoryResponse?.Channels?.FirstOrDefault(p => p.Name == channelName)?.Id;

	        return channelId;
		}
		
		#endregion

		#region Pin

		private static async Task<SlackBaseResponse> PinMessageAsync()
		{
			var (pinResponse, _) = await PinMessageInternalAsync();

			return pinResponse;
		}
		
		private static async Task<PinListResponse> GetPinListAsync()
		{
			var (_, sendMessageResponse) = await PinMessageInternalAsync();
			await PinMessageInternalAsync();

			return await _slackClient.GetPinListAsync(new PinListRequest(sendMessageResponse.ChannelId));
		}

		private static async Task<SlackBaseResponse> RemovePinAsync()
		{
			var (_, sendMessageResponse) = await PinMessageInternalAsync();
			
			return await _slackClient.RemovePinAsync(new PinItemToRemove(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp));
		}

		private static async Task<(SlackBaseResponse PinResponse, SendMessageResponse SendMessageResponse)> PinMessageInternalAsync()
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(PinMessageInternalAsync));

			var pinItem = new PinItem(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp);
			var pinMessageResponse = await _slackClient.PinMessageAsync(pinItem);

			return (pinMessageResponse, sendMessageResponse);
		}
		
		#endregion

		#region Reaction

		private static async Task<SlackBaseResponse> AddReactionAsync()
		{
			var (addReactionResponse, _) = await AddReactionInternalAsync();

			return addReactionResponse;
		}
		
		private static async Task<ReactionsByItemResponse> GetReactionsByItemAsync()
		{
			var (_, sendMessageResponse) = await AddReactionInternalAsync();
			await AddReactionToMessageAsync(sendMessageResponse, "smile");

			return await _slackClient.GetReactionsByItemAsync(new ReactionsByItemRequest(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp));
		}
		
		private static async Task<ReactionsByUserResponse> GetReactionsByUserAsync()
		{
			var (_, sendMessageResponse) = await AddReactionInternalAsync();
			await AddReactionToMessageAsync(sendMessageResponse, "smile");

			return await _slackClient.GetReactionsByUserAsync(new ReactionsByUserRequest());
		}
		
		private static async Task<SlackBaseResponse> RemoveReactionAsync()
		{
			const string EmojiName = "grin";
			var (_, sendMessageResponse) = await AddReactionInternalAsync(EmojiName);
			
			return await _slackClient.RemoveReactionAsync(new ReactionToRemove(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, EmojiName));
		}

		private static async Task<(SlackBaseResponse AddReactionResponse, SendMessageResponse SendMessageResponse)> AddReactionInternalAsync(
			string emojiName = "+1")
		{
			var sendMessageResponse = await SendSimpleMessageAsync(nameof(AddReactionAsync));

			var addReactionResponse = await AddReactionToMessageAsync(sendMessageResponse, emojiName);

			return (addReactionResponse, sendMessageResponse);
		}

		private static Task<SlackBaseResponse> AddReactionToMessageAsync(SendMessageResponse sendMessageResponse, string emojiName)
			=> _slackClient.AddReactionAsync(new Reaction(sendMessageResponse.ChannelId, sendMessageResponse.Timestamp, emojiName));

		#endregion

		#region TeamProfile
		
		private static async Task<TeamProfileResponse> GetTeamProfileAsync()
			=> await _slackClient.TeamProfileAsync(new TeamProfileRequest(TeamFieldVisibilityType.Visible));

		#endregion

		#region User

		private static Task<ConversationListResponse> GetUserConversationsAsync()
			=> _slackClient.UserConversationsAsync(new UserConversations("public_channel,private_channel,mpim,im"));

		private static Task<UserPresenceResponse> GetUserPresenceAsync()
			=> _slackClient.UserPresenceAsync(new UserPresenceRequest(_slackBotSettings.UserId));

		private static Task<UserResponse> GetUserInfoAsync()
			=> _slackClient.UserInfoAsync(new UserToGetInfo(_slackBotSettings.UserId));

		private static Task<UserListResponse> GetUserListAsync()
			=> _slackClient.UserListAsync(new UserListRequest());

		private static Task<UserResponse> GetUserByEmailAsync()
			=> _slackClient.UserByEmailAsync(new UserByEmailRequest(_slackBotSettings.UserEmail));

		private static Task<SlackBaseResponse> SetUserPresenceAsync()
			=> _slackClient.SetUserPresenceAsync(new SetUserPresenceRequest("auto"));
		
		#endregion

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