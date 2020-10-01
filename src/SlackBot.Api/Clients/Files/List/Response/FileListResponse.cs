using System.Collections.Generic;

namespace SlackBot.Api.Clients
{
	public class FileListResponse : ClassicPaginationResponseBase
	{
		public List<SlackFile> Files { get; set; }
	}
}