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
		
		/// <summary>
		/// Deletes a file.
		/// </summary>
		public Task<SlackBaseResponse> DeleteAsync(FileToDelete fileToDelete)
			=> SendPostFormUrlEncodedAsync("delete", fileToDelete);
		
		/// <summary>
		/// Gets information about a file.
		/// </summary>
		public Task<FileInfoResponse> InfoAsync(FileInfoRequest fileInfoRequest)
			=> SendGetAsync<FileInfoRequest, FileInfoResponse>("info", fileInfoRequest);
		
		/// <summary>
		/// List for a team, in a channel, or from a user with applied filters.
		/// </summary>
		public Task<FileListResponse> ListAsync(FileListRequest fileListRequest)
			=> SendGetAsync<FileListRequest, FileListResponse>("list", fileListRequest);

		/// <summary>
		/// Creates content as a file and uploads it.
		/// </summary>
		public Task<FileObjectResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> SendPostMultipartFormAsync<ContentToUpload, FileObjectResponse>("upload", contentToUpload);

		/// <summary>
		/// Uploads a file.
		/// </summary>
		public Task<FileObjectResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> SendPostMultipartFormAsync<FileToUpload, FileObjectResponse>("upload", fileToUpload);
	}
}