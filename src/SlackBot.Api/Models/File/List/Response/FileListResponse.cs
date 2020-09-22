using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Pagination.Classic;

namespace SlackBot.Api.Models.File.List.Response
{
	public class FileListResponse : ClassicPaginationResponseBase
	{
		public SlackFile[] Files { get; set; }
	}
}