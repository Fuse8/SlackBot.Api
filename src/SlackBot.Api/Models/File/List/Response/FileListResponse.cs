using System.Collections.Generic;
using SlackBot.Api.Models.GeneralObjects.File;
using SlackBot.Api.Models.GeneralObjects.Pagination.Classic;

namespace SlackBot.Api.Models.File.List.Response
{
	public class FileListResponse : ClassicPaginationResponseBase
	{
		public List<SlackFile> Files { get; set; }
	}
}