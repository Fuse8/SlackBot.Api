using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class SlackFile
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("created")]
		public long Created { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("mimetype")]
		public string MimeType { get; set; }

		[JsonProperty("filetype")]
		public string FileType { get; set; }

		[JsonProperty("pretty_type")]
		public string PrettyType { get; set; }

		[JsonProperty("user")]
		public string UserId { get; set; }

		[JsonProperty("editable")]
		public bool Editable { get; set; }

		[JsonProperty("size")]
		public long SizeBytes { get; set; }

		[JsonProperty("mode")]
		public string Mode { get; set; }

		[JsonProperty("is_external")]
		public bool IsExternal { get; set; }

		[JsonProperty("external_type")]
		public string ExternalType { get; set; }

		[JsonProperty("is_public")]
		public bool IsPublic { get; set; }

		[JsonProperty("public_url_shared")]
		public bool PublicUrlShared { get; set; }

		[JsonProperty("display_as_bot")]
		public bool DisplayAsBot { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("url_private")]
		public Uri UrlPrivate { get; set; }

		[JsonProperty("url_private_download")]
		public Uri UrlPrivateDownload { get; set; }

		[JsonProperty("permalink")]
		public Uri Permalink { get; set; }

		[JsonProperty("permalink_public")]
		public Uri PermalinkPublic { get; set; }

		[JsonProperty("edit_link")]
		public Uri EditLink { get; set; }

		[JsonProperty("preview")]
		public string Preview { get; set; }

		[JsonProperty("preview_highlight")]
		public string PreviewHighlight { get; set; }

		[JsonProperty("lines")]
		public long Lines { get; set; }

		[JsonProperty("lines_more")]
		public long LinesMore { get; set; }

		[JsonProperty("preview_is_truncated")]
		public bool PreviewIsTruncated { get; set; }

		[JsonProperty("comments_count")]
		public long CommentsCount { get; set; }

		[JsonProperty("is_starred")]
		public bool IsStarred { get; set; }

		[JsonProperty("shares")]
		public Shares Shares { get; set; }

		[JsonProperty("channels")]
		public string[] Channels { get; set; }

		[JsonProperty("groups")]
		public string[] Groups { get; set; }

		[JsonProperty("ims")]
		public string[] DirectMessageChannels { get; set; }

		[JsonProperty("has_rich_preview")]
		public bool HasRichPreview { get; set; }
        
		[JsonProperty("thumb_64")]
		public Uri Thumb64 { get; set; }

		[JsonProperty("thumb_80")]
		public Uri Thumb80 { get; set; }

		[JsonProperty("thumb_360")]
		public Uri Thumb360 { get; set; }

		[JsonProperty("thumb_360_w")]
		public long? Thumb360Wight { get; set; }

		[JsonProperty("thumb_360_h")]
		public long? Thumb360Height { get; set; }

		[JsonProperty("thumb_160")]
		public Uri Thumb160 { get; set; }

		[JsonProperty("original_w")]
		public long? OriginalWight { get; set; }

		[JsonProperty("original_h")]
		public long? OriginalHeight { get; set; }

		[JsonProperty("thumb_tiny")]
		public string ThumbTiny { get; set; }
	}
}