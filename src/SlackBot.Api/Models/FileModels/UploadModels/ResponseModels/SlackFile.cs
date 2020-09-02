using System;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.FileModels.UploadModels.ResponseModels
{
	public class SlackFile
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("created")]
		public long Created { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("mimetype")]
		public string MimeType { get; set; }

		[JsonPropertyName("filetype")]
		public string FileType { get; set; }

		[JsonPropertyName("pretty_type")]
		public string PrettyType { get; set; }

		[JsonPropertyName("user")]
		public string UserId { get; set; }

		[JsonPropertyName("editable")]
		public bool Editable { get; set; }

		[JsonPropertyName("size")]
		public long SizeBytes { get; set; }

		[JsonPropertyName("mode")]
		public string Mode { get; set; }

		[JsonPropertyName("is_external")]
		public bool IsExternal { get; set; }

		[JsonPropertyName("external_type")]
		public string ExternalType { get; set; }

		[JsonPropertyName("is_public")]
		public bool IsPublic { get; set; }

		[JsonPropertyName("public_url_shared")]
		public bool PublicUrlShared { get; set; }

		[JsonPropertyName("display_as_bot")]
		public bool DisplayAsBot { get; set; }

		[JsonPropertyName("username")]
		public string Username { get; set; }

		[JsonPropertyName("url_private")]
		public Uri UrlPrivate { get; set; }

		[JsonPropertyName("url_private_download")]
		public Uri UrlPrivateDownload { get; set; }

		[JsonPropertyName("permalink")]
		public Uri Permalink { get; set; }

		[JsonPropertyName("permalink_public")]
		public Uri PermalinkPublic { get; set; }

		[JsonPropertyName("edit_link")]
		public Uri EditLink { get; set; }

		[JsonPropertyName("preview")]
		public string Preview { get; set; }

		[JsonPropertyName("preview_highlight")]
		public string PreviewHighlight { get; set; }

		[JsonPropertyName("lines")]
		public long Lines { get; set; }

		[JsonPropertyName("lines_more")]
		public long LinesMore { get; set; }

		[JsonPropertyName("preview_is_truncated")]
		public bool PreviewIsTruncated { get; set; }

		[JsonPropertyName("comments_count")]
		public long CommentsCount { get; set; }

		[JsonPropertyName("is_starred")]
		public bool IsStarred { get; set; }

		[JsonPropertyName("shares")]
		public Shares Shares { get; set; }

		[JsonPropertyName("channels")]
		public string[] Channels { get; set; }

		[JsonPropertyName("groups")]
		public string[] Groups { get; set; }

		[JsonPropertyName("ims")]
		public string[] DirectMessageChannels { get; set; }

		[JsonPropertyName("has_rich_preview")]
		public bool HasRichPreview { get; set; }
        
		[JsonPropertyName("thumb_64")]
		public Uri Thumb64 { get; set; }

		[JsonPropertyName("thumb_80")]
		public Uri Thumb80 { get; set; }

		[JsonPropertyName("thumb_360")]
		public Uri Thumb360 { get; set; }

		[JsonPropertyName("thumb_360_w")]
		public long? Thumb360Wight { get; set; }

		[JsonPropertyName("thumb_360_h")]
		public long? Thumb360Height { get; set; }

		[JsonPropertyName("thumb_160")]
		public Uri Thumb160 { get; set; }

		[JsonPropertyName("original_w")]
		public long? OriginalWight { get; set; }

		[JsonPropertyName("original_h")]
		public long? OriginalHeight { get; set; }

		[JsonPropertyName("thumb_tiny")]
		public string ThumbTiny { get; set; }
	}
}