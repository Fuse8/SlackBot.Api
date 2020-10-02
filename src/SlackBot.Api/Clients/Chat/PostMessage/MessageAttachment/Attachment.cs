﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class Attachment
	{
		[JsonProperty("fallback")]
		public string Fallback { get; set; }

		[JsonProperty("color")]
		public string Color { get; set; }

		[JsonProperty("blocks")]
		public List<BlockBase> Blocks { get; set; }

		[JsonProperty("pretext")]
		public string Pretext { get; set; }

		[JsonProperty("author_name")]
		public string AuthorName { get; set; }

		[JsonProperty("author_link")]
		public Uri AuthorLink { get; set; }

		[JsonProperty("author_icon")]
		public Uri AuthorIconUrl { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("title_link")]
		public Uri TitleLink { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("fields")]
		public List<Field> Fields { get; set; }

		[JsonProperty("image_url")]
		public Uri ImageUrl { get; set; }

		[JsonProperty("thumb_url")]
		public Uri ThumbUrl { get; set; }

		[JsonProperty("footer")]
		public string Footer { get; set; }

		[JsonProperty("footer_icon")]
		public Uri FooterIconUrl { get; set; }

		[JsonProperty("ts")]
		public long? Timestamp { get; set; }
	}
}