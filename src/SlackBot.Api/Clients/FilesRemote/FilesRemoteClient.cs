using System;
using System.IO;
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
		
		/// <inheritdoc cref="AddAsync(RemoteFile)"/>
		public Task<FileObjectResponse> AddAsync(
			string externalId,
			Uri externalUrl,
			string title = null,
			Stream previewImageStream = null,
			string fileType = null,
			Stream indexableContentStream = null)
			=> AddAsync(new RemoteFile(externalId, externalUrl, title, previewImageStream, fileType, indexableContentStream));
		
		/// <summary>
		/// Adds a file from a remote service.
		/// </summary>
		public Task<FileObjectResponse> AddAsync(RemoteFile remoteFile)
			=> SendPostMultipartFormAsync<RemoteFile, FileObjectResponse>("add", remoteFile);

		/// <inheritdoc cref="InfoAsync(RemoteFileInfoRequest)"/>
		public Task<FileObjectResponse> InfoAsync(string fileId = null, string externalId = null)
			=> InfoAsync(new RemoteFileInfoRequest(fileId, externalId));

		/// <summary>
		/// Retrieve information about a remote file added to Slack.
		/// </summary>
		public Task<FileObjectResponse> InfoAsync(RemoteFileInfoRequest remoteFileInfoRequest)
			=> SendGetAsync<RemoteFileInfoRequest, FileObjectResponse>("info", remoteFileInfoRequest);

		/// <inheritdoc cref="ListAsync(RemoteFileListRequest)"/>
		public Task<RemoteFileListResponse> ListAsync(
			string channelId = null,
			string timestampFrom = null,
			string timestampTo = null,
			string cursor = null,
			long? limit = null)
			=> ListAsync(new RemoteFileListRequest(channelId, timestampFrom, timestampTo, cursor, limit));

		/// <summary>
		/// Retrieve information about a remote file added to Slack.
		/// </summary>
		public Task<RemoteFileListResponse> ListAsync(RemoteFileListRequest remoteFileListRequest)
			=> SendGetAsync<RemoteFileListRequest, RemoteFileListResponse>("list", remoteFileListRequest);

		/// <inheritdoc cref="RemoveAsync(RemoteFileToRemove)"/>
		public Task<SlackBaseResponse> RemoveAsync(string fileId = null, string externalId = null)
			=> RemoveAsync(new RemoteFileToRemove(fileId, externalId));

		/// <summary>
		/// Remove a remote file.
		/// </summary>
		public Task<SlackBaseResponse> RemoveAsync(RemoteFileToRemove remoteFileToRemove)
			=> SendPostFormUrlEncodedAsync("remove", remoteFileToRemove);

		/// <inheritdoc cref="ShareAsync(RemoteFileToShare)"/>
		public Task<FileObjectResponse> ShareAsync(string chanelIds, string fileId = null, string externalId = null)
			=> ShareAsync(new RemoteFileToShare(chanelIds, fileId, externalId));

		/// <summary>
		/// Share a remote file into a channel.
		/// </summary>
		public Task<FileObjectResponse> ShareAsync(RemoteFileToShare remoteFileToShare)
			=> SendPostFormUrlEncodedAsync<RemoteFileToShare, FileObjectResponse>("share", remoteFileToShare);

		/// <inheritdoc cref="UpdateAsync(RemoteFileToUpdate)"/>
		public Task<FileObjectResponse> UpdateAsync(
			string fileId = null,
			Uri externalUrl = null,
			string title = null,
			Stream previewImageStream = null,
			string fileType = null,
			Stream indexableContentStream = null,
			string externalId = null)
			=> UpdateAsync(new RemoteFileToUpdate(fileId, externalUrl, title, previewImageStream, fileType, indexableContentStream, externalId));

		/// <summary>
		/// Updates an existing remote file.
		/// </summary>
		public Task<FileObjectResponse> UpdateAsync(RemoteFileToUpdate remoteFileToUpdate)
			=> SendPostFormUrlEncodedAsync<RemoteFileToUpdate, FileObjectResponse>("update", remoteFileToUpdate);
	}
}