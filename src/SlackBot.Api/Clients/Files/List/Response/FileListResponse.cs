using System.Collections.Generic;
using SlackBot.Api.Clients.GeneralObjects.File;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Classic;

namespace SlackBot.Api.Clients.List.Response
{
	public class FileListResponse : ClassicPaginationResponseBase
	{
		public List<SlackFile> Files { get; set; }
	}
}