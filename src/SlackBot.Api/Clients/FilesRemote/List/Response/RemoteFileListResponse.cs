using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.GeneralObjects.File;
using SlackBot.Api.Clients.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Clients.List.Response
{
	public class RemoteFileListResponse : CursorPaginationResponseBase
	{
		[JsonProperty("files")]
		public List<SlackFile> Files { get; set; }
	}
}