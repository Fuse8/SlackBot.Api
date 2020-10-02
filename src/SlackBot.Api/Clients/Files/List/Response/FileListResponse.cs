using System.Collections.Generic;

namespace SlackBot.Api
{
	public class FileListResponse : ClassicPaginationResponseBase
	{
		public List<SlackFile> Files { get; set; }
	}
}