using System;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel
{
	public class Attachment
	{
		[JsonPropertyName("fallback")]
		public string Fallback { get; set; }

		[JsonPropertyName("color")]
		public string Color { get; set; }

		[JsonPropertyName("pretext")]
		public string Pretext { get; set; }

		[JsonPropertyName("author_name")]
		public string AuthorName { get; set; }

		[JsonPropertyName("author_link")]
		public Uri AuthorLink { get; set; }

		[JsonPropertyName("author_icon")]
		public Uri AuthorIcon { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("title_link")]
		public Uri TitleLink { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("fields")]
		public Field[] Fields { get; set; }

		[JsonPropertyName("image_url")]
		public Uri ImageUrl { get; set; }

		[JsonPropertyName("thumb_url")]
		public Uri ThumbUrl { get; set; }

		[JsonPropertyName("footer")]
		public string Footer { get; set; }

		[JsonPropertyName("footer_icon")]
		public Uri FooterIcon { get; set; }

		[JsonPropertyName("ts")]
		public long Ts { get; set; }
	}
}