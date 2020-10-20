using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class FilesClient : SlackClientBase
	{
		public FilesClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "files";
		
		/// <inheritdoc cref="DeleteAsync(FileToDelete)"/>
		public Task<SlackBaseResponse> DeleteAsync(string fileId)
			=> DeleteAsync(new FileToDelete(fileId));
		
		/// <summary>
		/// Deletes a file.
		/// </summary>
		public Task<SlackBaseResponse> DeleteAsync(FileToDelete fileToDelete)
			=> SendPostFormUrlEncodedAsync("delete", fileToDelete);
		
		/// <inheritdoc cref="InfoAsync(FileInfoRequest)"/>
		public Task<FileInfoResponse> InfoAsync(string fileId)
			=> InfoAsync(new FileInfoRequest(fileId));
		
		/// <summary>
		/// Gets information about a file.
		/// </summary>
		public Task<FileInfoResponse> InfoAsync(FileInfoRequest fileInfoRequest)
			=> SendGetAsync<FileInfoRequest, FileInfoResponse>("info", fileInfoRequest);
		
		/// <inheritdoc cref="ListAsync(FileListRequest)"/>
		public Task<FileListResponse> ListAsync(string channelId, string timestampFrom = null, string timestampTo = null, long? count = null, long? page = null)
			=> ListAsync(new FileListRequest(channelId, timestampFrom, timestampTo, count, page));
		
		/// <summary>
		/// List for a team, in a channel, or from a user with applied filters.
		/// </summary>
		public Task<FileListResponse> ListAsync(FileListRequest fileListRequest)
			=> SendGetAsync<FileListRequest, FileListResponse>("list", fileListRequest);

		/// <inheritdoc cref="UploadContentAsync(ContentToUpload)"/>
		public Task<FileObjectResponse> UploadContentAsync(
			string content,
			string channelNamesOrIds = null,
			string filename = null,
			string comment = null,
			string title = null,
			string fileType = null,
			string threadTimestamp = null)
			=> UploadContentAsync(new ContentToUpload(content, channelNamesOrIds, filename, comment, title, fileType, threadTimestamp));

		/// <summary>
		/// Creates content as a file and uploads it.
		/// </summary>
		public Task<FileObjectResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> SendPostMultipartFormAsync<ContentToUpload, FileObjectResponse>("upload", contentToUpload);

		/// <inheritdoc cref="UploadFileAsync(FileToUpload)"/>
		public Task<FileObjectResponse> UploadFileAsync(
			Stream stream,
			string channelNamesOrIds = null,
			string filename = null,
			string comment = null,
			string title = null,
			string fileType = null,
			string threadTimestamp = null)
			=> UploadFileAsync(new FileToUpload(stream, channelNamesOrIds, filename, comment, title, fileType, threadTimestamp));

		/// <summary>
		/// Uploads a file.
		/// </summary>
		public Task<FileObjectResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> SendPostMultipartFormAsync<FileToUpload, FileObjectResponse>("upload", fileToUpload);
	}
}