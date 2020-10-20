using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class FilesClientMethods
	{
		public static async Task<FileObjectResponse> UploadContentAsync(SlackClient slackClient, string channelName, string title = "Title")
		{
			var content = await File.ReadAllTextAsync("./appsettings.json");
			var contentMessage = new ContentToUpload
			{
				Comment = $"{nameof(UploadContentAsync)} method",
				Title = title,
				ChannelNamesOrIds = channelName,
				Content = content,
				Filename = "appsettings.json",
				FileType = "javascript",
			};

			return await slackClient.Files.UploadContentAsync(contentMessage);
		}

		public static async Task<FileObjectResponse> UploadFileAsync(SlackClient slackClient, string channelName)
		{
			await using var fileStream = File.Open("./appsettings.json", FileMode.Open);
			var fileMessage = new FileToUpload
			{
				ChannelNamesOrIds = channelName,
				Stream = fileStream,
				Comment = $"{nameof(UploadFileAsync)} method"
			};

			return await slackClient.Files.UploadFileAsync(fileMessage);
		}

		public static async Task<SlackBaseResponse> DeleteFileAsync(SlackClient slackClient, string channelName)
		{
			var uploadFileResponse = await UploadFileAsync(slackClient, channelName);
			
			return await slackClient.Files.DeleteAsync(uploadFileResponse.File.Id);
		}

		public static async Task<FileInfoResponse> GetFileInfoAsync(SlackClient slackClient, string channelName)
		{
			var uploadFileResponse = await UploadFileAsync(slackClient, channelName);
			
			return await slackClient.Files.InfoAsync(uploadFileResponse.File.Id);
		}

		public static async Task<FileListResponse> GetFileListAsync(SlackClient slackClient, string channelName)
		{
			var uploadFileResponse = await UploadFileAsync(slackClient, channelName);
			await UploadContentAsync(slackClient, channelName);

			// Because of slack cache... Files upload instantly, but they attach to group delayed
			await Task.Delay(30000);
			
			var firstFile = uploadFileResponse.File;
			var fileListRequest = new FileListRequest
			{
				ChannelId = firstFile.ChannelIds.FirstOrDefault() ?? firstFile.GroupIds.FirstOrDefault(),
				TimestampFrom = firstFile.CreatedTimestamp.ToString(),
			};

			return await slackClient.Files.ListAsync(fileListRequest);
		}
	}
}