using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api.Clients
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
		public Task<SlackFileResponse> AddAsync(RemoteFile remoteFile)
			=> SendPostMultipartFormAsync<RemoteFile, SlackFileResponse>("add", remoteFile);

		/// <summary>
		/// Retrieve information about a remote file added to Slack.
		/// </summary>
		public Task<SlackFileResponse> InfoAsync(RemoteFileInfoRequest remoteFileInfoRequest)
			=> SendGetAsync<RemoteFileInfoRequest, SlackFileResponse>("info", remoteFileInfoRequest);

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
		public Task<SlackFileResponse> ShareAsync(RemoteFileToShare remoteFileToShare)
			=> SendPostFormUrlEncodedAsync<RemoteFileToShare, SlackFileResponse>("share", remoteFileToShare);

		/// <summary>
		/// Updates an existing remote file.
		/// </summary>
		public Task<SlackFileResponse> UpdateAsync(RemoteFileToUpdate remoteFileToUpdate)
			=> SendPostFormUrlEncodedAsync<RemoteFileToUpdate, SlackFileResponse>("update", remoteFileToUpdate);
	}
}