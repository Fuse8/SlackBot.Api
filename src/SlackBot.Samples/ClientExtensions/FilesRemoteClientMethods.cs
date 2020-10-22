using System;
using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class FilesRemoteClientMethods
	{
		public static Task<FileObjectResponse> AddRemoteFileAsync(SlackClient slackClient)
		{
			var remoteFile = new RemoteFile
			{
				ExternalId = Guid.NewGuid().ToString(),
				ExternalUrl = new Uri("https://unsplash.com/photos/Dl39g6QhOIM"),
				Title = "Beautiful cat",
				FileType = "jpg",
			};

			return slackClient.FilesRemote.AddAsync(remoteFile);
		}

		public static async Task<FileObjectResponse> GetRemoteFileInfoAsync(SlackClient slackClient)
		{
			var addRemoteFileResponse = await AddRemoteFileAsync(slackClient);

			return await slackClient.FilesRemote.InfoAsync(addRemoteFileResponse.File.Id);
		}

		public static async Task<RemoteFileListResponse> GetRemoteFileListAsync(SlackClient slackClient)
		{
			await AddRemoteFileAsync(slackClient);
			
			// Because of slack cache... Files upload instantly, but they return in method "files.remote.list" with delay
			await Task.Delay(30000);

			return await slackClient.FilesRemote.ListAsync();
		}

		public static async Task<SlackBaseResponse> RemoveRemoteFileAsync(SlackClient slackClient)
		{
			var addRemoteFileResponse = await AddRemoteFileAsync(slackClient);

			return await slackClient.FilesRemote.RemoveAsync(addRemoteFileResponse.File.Id);
		}

		public static async Task<FileObjectResponse> ShareRemoteFileAsync(SlackClient slackClient, string channelName)
		{
			var addRemoteFileResponse = await AddRemoteFileAsync(slackClient);
			
			var channelId = await ConversationsClientMethods.GetChannelIdAsync(slackClient, channelName);

			return await slackClient.FilesRemote.ShareAsync(channelId, addRemoteFileResponse.File.Id);
		}

		public static async Task<FileObjectResponse> UpdateRemoteFileAsync(SlackClient slackClient)
		{
			var addRemoteFileResponse = await AddRemoteFileAsync(slackClient);

			var remoteFileToUpdate = new RemoteFileToUpdate
			{
				FileId = addRemoteFileResponse.File.Id,
				Title = "New title"
			};

			return await slackClient.FilesRemote.UpdateAsync(remoteFileToUpdate);
		}
	}
}