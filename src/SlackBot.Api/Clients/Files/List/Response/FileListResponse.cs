using System.Collections.Generic;

namespace SlackBot.Api
{
	public class FileListResponse : ClassicPaginationResponseBase
	{
		public List<FileObject> Files { get; set; }
	}
}