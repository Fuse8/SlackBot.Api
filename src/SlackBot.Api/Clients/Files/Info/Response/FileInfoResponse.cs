using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class FileInfoResponse : CursorPaginationResponseBase
	{
		[JsonProperty("file")]
		public FileObject File { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("is_truncated")]
		public bool? IsTruncated { get; set; }

		[JsonProperty("content_highlight_html")]
		public string ContentHighlightHtml { get; set; }

		[JsonProperty("content_highlight_css")]
		public string ContentHighlightCss { get; set; }

		[JsonProperty("comments")]
		public List<object> Comments { get; set; }  // TODO Couldn't find a description of this field in the documentation
	}
}