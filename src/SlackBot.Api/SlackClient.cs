using System.Net.Http;
using System.Threading.Tasks;
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
using SlackBot.Api.Models.Reaction.List.Request;
using SlackBot.Api.Models.Reaction.List.Response;
using SlackBot.Api.Models.Reaction.Remove.Request;
using SlackBot.Api.Models.User.Conversation.Request;
using SlackBot.Api.Models.User.Conversation.Response;
using SlackBot.Api.Models.User.GetPresence.Request;
using SlackBot.Api.Models.User.GetPresence.Response;

namespace SlackBot.Api
{
    public class SlackClient : SlackClientBase
	{
		public SlackClient(HttpClient httpClient)
            : base(httpClient)
		{
		}

		/// <summary>
		/// Gets information about a bot user.
		/// </summary>
		public Task<BotInfoResponse> GetBotInfoAsync(BotInfoRequest botInfoRequest)
			=> SendGetAsync<BotInfoRequest, BotInfoResponse>("bots.info", botInfoRequest);

		#region File
		
		/// <summary>
		/// Deletes a file.
		/// </summary>
		public Task<SlackBaseResponse> DeleteFileAsync(FileToDelete fileToDelete)
			=> SendPostFormUrlEncodedAsync<FileToDelete, SlackBaseResponse>("files.delete", fileToDelete);
		
		/// <summary>
		/// Gets information about a file.
		/// </summary>
		public Task<FileInfoResponse> GetFileInfoAsync(FileInfoRequest fileInfoRequest)
			=> SendGetAsync<FileInfoRequest, FileInfoResponse>("files.info", fileInfoRequest);
		
		/// <summary>
		/// List for a team, in a channel, or from a user with applied filters.
		/// </summary>
		public Task<FileListResponse> GetFileListAsync(FileListRequest fileListRequest)
			=> SendGetAsync<FileListRequest, FileListResponse>("files.list", fileListRequest);

		/// <summary>
		/// Creates content as a file and uploads it.
		/// </summary>
		public Task<UploadFileResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> SendPostMultipartFormAsync<ContentToUpload, UploadFileResponse>("files.upload", contentToUpload);

		/// <summary>
		/// Uploads a file.
		/// </summary>
		public Task<UploadFileResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> SendPostMultipartFormAsync<FileToUpload, UploadFileResponse>("files.upload", fileToUpload);
		
		#endregion
		
		#region Chat

		/// <summary>
		/// Deletes a message.
		/// </summary>
		public Task<DeletedMessageResponse> DeleteMessageAsync(MessageToDelete messageToDelete)
			=> SendPostFormUrlEncodedAsync<MessageToDelete, DeletedMessageResponse>("chat.delete", messageToDelete);

		/// <summary>
		/// Deletes a pending scheduled message from the queue.
		/// </summary>
		public Task<SlackBaseResponse> DeleteScheduledMessageAsync(ScheduledMessageToDelete scheduledMessageToDelete)
			=> SendPostJsonStringAsync<ScheduledMessageToDelete, SlackBaseResponse>("chat.deleteScheduledMessage", scheduledMessageToDelete);

		/// <summary>
		/// Retrieve a permalink URL for a specific extant message.
		/// </summary>
		public Task<MessagePermalinkResponse> GetMessagePermalinkAsync(MessagePermalinkRequest messagePermalinkRequest)
			=> SendGetAsync<MessagePermalinkRequest, MessagePermalinkResponse>("chat.getPermalink", messagePermalinkRequest);

		/// <summary>
		/// Sends an ephemeral message to a user in a channel.
		/// </summary>
		public Task<SendEphemeralMessageResponse> SendEphemeralMessageAsync(EphemeralMessage ephemeralMessage)
			=> SendPostJsonStringAsync<EphemeralMessage, SendEphemeralMessageResponse>("chat.postEphemeral", ephemeralMessage);

		/// <summary>
		/// Sends a message to a channel.
		/// </summary>
		public Task<SendMessageResponse> SendMessageAsync(Message message)
			=> SendPostJsonStringAsync<Message, SendMessageResponse>("chat.postMessage", message);
		
		/// <summary>
		/// Schedules a message to be sent to a channel.
		/// </summary>
		public Task<ScheduleMessageResponse> ScheduleMessageAsync(MessageToSchedule messageToSchedule)
			=> SendPostJsonStringAsync<MessageToSchedule, ScheduleMessageResponse>("chat.scheduleMessage", messageToSchedule);
		
		/// <summary>
		/// Returns a list of scheduled messages.
		/// </summary>
		public Task<ScheduledMessageListResponse> GetScheduledMessages(ScheduledMessageListRequest scheduledMessageListRequest)
			=> SendPostFormUrlEncodedAsync<ScheduledMessageListRequest, ScheduledMessageListResponse>("chat.scheduledMessages.list", scheduledMessageListRequest);
		
		/// <summary>
		/// Updates a message.
		/// </summary>
		public Task<UpdateMessageResponse> UpdateMessage(MessageToUpdate messageToUpdate)
			=> SendPostJsonStringAsync<MessageToUpdate, UpdateMessageResponse>("chat.update", messageToUpdate);
		
		#endregion

		#region Pin

		/// <summary>
		/// Pins an item to a channel.
		/// </summary>
		public Task<SlackBaseResponse> PinMessageAsync(PinItem pinItem)
			=> SendPostFormUrlEncodedAsync<PinItem, SlackBaseResponse>("pins.add", pinItem);

		/// <summary>
		/// Lists items pinned to a channel.
		/// </summary>
		public Task<PinListResponse> GetPinListAsync(PinListRequest pinListRequest)
			=> SendGetAsync<PinListRequest, PinListResponse>("pins.list", pinListRequest);

		/// <summary>
		/// Un-pins an item from a channel.
		/// </summary>
		public Task<SlackBaseResponse> RemovePinAsync(PinItemToRemove pinItemToRemove)
			=> SendPostFormUrlEncodedAsync<PinItemToRemove, SlackBaseResponse>("pins.remove", pinItemToRemove);

		#endregion

		#region Reaction

		/// <summary>
		/// Adds a reaction to an item.
		/// </summary>
		public Task<SlackBaseResponse> AddReactionAsync(Reaction reaction)
			=> SendPostFormUrlEncodedAsync<Reaction, SlackBaseResponse>("reactions.add", reaction);

		/// <summary>
		/// Gets reactions for an item.
		/// </summary>
		public Task<GetReactionsByItemResponse> GetReactionsByItemAsync(GetReactionsByItemRequest getReactionsByItemRequest)
			=> SendGetAsync<GetReactionsByItemRequest, GetReactionsByItemResponse>("reactions.get", getReactionsByItemRequest);

		/// <summary>
		/// Lists reactions made by a user.
		/// </summary>
		public Task<GetReactionsByUserResponse> GetReactionsByUserAsync(GetReactionsByUserRequest getReactionsByUserRequest)
			=> SendGetAsync<GetReactionsByUserRequest, GetReactionsByUserResponse>("reactions.list", getReactionsByUserRequest);

		/// <summary>
		/// Removes a reaction from an item.
		/// </summary>
		public Task<SlackBaseResponse> RemoveReactionAsync(ReactionToRemove reactionToRemove)
			=> SendPostFormUrlEncodedAsync<ReactionToRemove, SlackBaseResponse>("reactions.remove", reactionToRemove);

		#endregion

		#region User

		/// <summary>
		/// Gets conversations list the calling user may access.
		/// </summary>
		public Task<UserConversationsResponse> UserConversationsAsync(UserConversations userConversations)
			=> SendGetAsync<UserConversations, UserConversationsResponse>("users.conversations", userConversations);

		/// <summary>
		/// Gets user presence information.
		/// </summary>
		public Task<UserPresenceResponse> UserPresenceAsync(UserPresenceRequest userPresenceRequest)
			=> SendGetAsync<UserPresenceRequest, UserPresenceResponse>("users.getPresence", userPresenceRequest);
		
		#endregion
        
		/// <summary>
		/// Fetches a conversation's history of messages and events.
		/// </summary>
        public Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistory conversationsHistory) 
            => SendGetAsync<ConversationsHistory, ConversationsHistoryResponse>("conversations.history", conversationsHistory);
	}
}