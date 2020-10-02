using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class RemoteFileListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("files")]
		public List<SlackFile> Files { get; set; }
	}
}