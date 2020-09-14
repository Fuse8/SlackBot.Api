using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.MessageAttachment;

namespace SlackBot.Api.Models.Chat.PostMessage
{
	public class Message
	{
		[JsonProperty("channel")]
		public string Channel { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("as_user")]
		public bool? AsUser { get; set; }

		[JsonProperty("attachments")]
		public Attachment[] Attachments { get; set; }

		[JsonProperty("blocks")]
		public BlockBase[] Blocks { get; set; }

		[JsonProperty("icon_emoji")]
		public string IconEmoji { get; set; }

		[JsonProperty("icon_url")]
		public Uri IconUrl { get; set; }

		[JsonProperty("linkNames")]
		public bool? LinkNames { get; set; }

		[JsonProperty("mrkdwn")]
		public bool? Mrkdwn { get; set; }

		[JsonProperty("parse")]
		public string Parse { get; set; }

		[JsonProperty("reply_broadcast")]
		public bool? ReplyBroadcast { get; set; }

		[JsonProperty("ThreadId")]
		public string ThreadId { get; set; }

		[JsonProperty("unfurl_links")]
		public bool? UnfurlLinks { get; set; }

		[JsonProperty("unfurl_media")]
		public bool? UnfurlMedia { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }
	}
}