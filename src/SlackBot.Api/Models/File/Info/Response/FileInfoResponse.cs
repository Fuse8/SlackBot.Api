using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.File.Info.Response
{
	public class FileInfoResponse : CursorPaginationResponseBase
	{
		[JsonProperty("file")]
		public SlackFile File { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("is_truncated")]
		public bool? IsTruncated { get; set; }

		[JsonProperty("content_highlight_html")]
		public string ContentHighlightHtml { get; set; }

		[JsonProperty("content_highlight_css")]
		public string ContentHighlightCss { get; set; }

		[JsonProperty("comments")]
		public object[] Comments { get; set; }
	}
}