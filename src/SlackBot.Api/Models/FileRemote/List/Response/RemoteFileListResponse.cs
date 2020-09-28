using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.File;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.FileRemote.List.Response
{
	public class RemoteFileListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("files")]
		public SlackFile[] Files { get; set; }
	}
}