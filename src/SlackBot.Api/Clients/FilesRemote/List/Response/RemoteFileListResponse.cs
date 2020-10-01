using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class RemoteFileListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("files")]
		public List<SlackFile> Files { get; set; }
	}
}