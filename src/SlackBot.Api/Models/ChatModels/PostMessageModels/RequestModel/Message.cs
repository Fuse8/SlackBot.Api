using System;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel
{
	public class Message
	{
		[JsonPropertyName("channel")]
		public string Channel { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("as_user")]
		public bool? AsUser { get; set; }

		[JsonPropertyName("attachments")]
		public Attachment[] Attachments { get; set; }

		[JsonPropertyName("blocks")]
		public Block[] Blocks { get; set; }

		[JsonPropertyName("icon_emoji")]
		public string IconEmoji { get; set; }

		[JsonPropertyName("icon_url")]
		public Uri IconUrl { get; set; }

		[JsonPropertyName("linkNames")]
		public bool? LinkNames { get; set; }

		[JsonPropertyName("mrkdwn")]
		public bool? Mrkdwn { get; set; }

		[JsonPropertyName("parse")]
		public string Parse { get; set; }

		[JsonPropertyName("reply_broadcast")]
		public bool? ReplyBroadcast { get; set; }

		[JsonPropertyName("ThreadId")]
		public string ThreadId { get; set; }

		[JsonPropertyName("unfurl_links")]
		public bool? UnfurlLinks { get; set; }
		
		[JsonPropertyName("unfurl_media")]
		public bool? UnfurlMedia { get; set; }
		
		[JsonPropertyName("username")]
		public string Username { get; set; }
	}
}