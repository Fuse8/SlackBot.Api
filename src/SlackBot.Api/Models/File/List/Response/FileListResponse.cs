using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Pagination.Classic;

namespace SlackBot.Api.Models.File.List.Response
{
	public class FileListResponse : PagePaginationResponseBase
	{
		public SlackFile[] Files { get; set; }
	}
}