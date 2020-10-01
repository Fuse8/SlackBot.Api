using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models.File.Delete.Request;
using SlackBot.Api.Models.File.Info.Request;
using SlackBot.Api.Models.File.Info.Response;
using SlackBot.Api.Models.File.List.Request;
using SlackBot.Api.Models.File.List.Response;
using SlackBot.Api.Models.File.Upload.Request;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.File;

namespace SlackBot.Api.Clients
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
		public Task<SlackFileResponse> UploadContentAsync(ContentToUpload contentToUpload)
			=> SendPostMultipartFormAsync<ContentToUpload, SlackFileResponse>("upload", contentToUpload);

		/// <summary>
		/// Uploads a file.
		/// </summary>
		public Task<SlackFileResponse> UploadFileAsync(FileToUpload fileToUpload)
			=> SendPostMultipartFormAsync<FileToUpload, SlackFileResponse>("upload", fileToUpload);
	}
}