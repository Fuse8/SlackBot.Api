using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class FilesRemoteClient : SlackClientBase
	{
		public FilesRemoteClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "files.remote";
		
		/// <summary>
		/// Adds a file from a remote service.
		/// </summary>
		public Task<FileObjectResponse> AddAsync(RemoteFile remoteFile)
			=> SendPostMultipartFormAsync<RemoteFile, FileObjectResponse>("add", remoteFile);

		/// <summary>
		/// Retrieve information about a remote file added to Slack.
		/// </summary>
		public Task<FileObjectResponse> InfoAsync(RemoteFileInfoRequest remoteFileInfoRequest)
			=> SendGetAsync<RemoteFileInfoRequest, FileObjectResponse>("info", remoteFileInfoRequest);

		/// <summary>
		/// Retrieve information about a remote file added to Slack.
		/// </summary>
		public Task<RemoteFileListResponse> ListAsync(RemoteFileListRequest remoteFileListRequest)
			=> SendGetAsync<RemoteFileListRequest, RemoteFileListResponse>("list", remoteFileListRequest);

		/// <summary>
		/// Remove a remote file.
		/// </summary>
		public Task<SlackBaseResponse> RemoveAsync(RemoteFileToRemove remoteFileToRemove)
			=> SendPostFormUrlEncodedAsync("remove", remoteFileToRemove);

		/// <summary>
		/// Share a remote file into a channel.
		/// </summary>
		public Task<FileObjectResponse> ShareAsync(RemoteFileToShare remoteFileToShare)
			=> SendPostFormUrlEncodedAsync<RemoteFileToShare, FileObjectResponse>("share", remoteFileToShare);

		/// <summary>
		/// Updates an existing remote file.
		/// </summary>
		public Task<FileObjectResponse> UpdateAsync(RemoteFileToUpdate remoteFileToUpdate)
			=> SendPostFormUrlEncodedAsync<RemoteFileToUpdate, FileObjectResponse>("update", remoteFileToUpdate);
	}
}