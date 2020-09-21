using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.MessageAttachment;

namespace SlackBot.Api.Models.Chat.Update.Request
{
	public class MessageToUpdate
	{
		public MessageToUpdate()
		{
		}

		public MessageToUpdate(string channelId, string messageTimestamp, string text = null, Attachment[] attachments = null, BlockBase[] blocks = null)
		{
			ChannelId = channelId;
			MessageTimestamp = messageTimestamp;
			Text = text;
			Attachments = attachments;
			Blocks = blocks;
		}

		/// <summary>
		/// Channel containing the message to be updated.
		/// </summary>
		/// <example>C1234567890</example>
		[JsonProperty("channel")]
		public string ChannelId { get; set; }

		/// <summary>
		/// Timestamp of the message to be updated.
		/// </summary>
		/// <example>1405894322.002768</example>
		[JsonProperty("ts")]
		public string MessageTimestamp { get; set; }

		/// <summary>
		/// Pass "true" to update the message as the authed user. Bot users in this context are considered authed users.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[JsonProperty("as_user")]
		public bool? AsUser { get; set; }

		/// <summary>
		/// A JSON-based array of structured attachments, presented as a URL-encoded string. This field is required when not presenting <see cref="Text"/>.
		/// If you don't include this field, the message's previous <see cref="Attachments"/> will be retained.
		/// To remove previous <see cref="Attachments"/>, include an empty array for this field.
		/// </summary>
		/// <example>[{"pretext": "pre-hello", "text": "text-world"}]</example>
		[JsonProperty("attachments")]
		public Attachment[] Attachments { get; set; }

		/// <summary>
		/// A JSON-based array of structured blocks, presented as a URL-encoded string.
		/// If you don't include this field, the message's previous <see cref="Blocks"/> will be retained.
		/// To remove previous <see cref="Blocks"/>, include an empty array for this field.
		/// </summary>
		/// <example>[{"type": "section", "text": {"type": "plain_text", "text": "Hello world"}}]</example>
		[JsonProperty("blocks")]
		public BlockBase[] Blocks { get; set; }

		/// <summary>
		/// Find and link channel names and usernames.
		/// If you do not specify a value for this field, the original value set for the message will be overwritten with the default, "none".
		/// <para><strong>Default: none</strong></para>
		/// </summary>
		/// <example>true</example>
		[JsonProperty("link_names")]
		public bool? LinkNames { get; set; }

		/// <summary>
		/// Change how messages are treated. Defaults to "client", unlike "chat.postMessage". Accepts either "none" or "full".
		/// If you do not specify a value for this field, the original value set for the message will be overwritten with the default, "client".
		/// <para><strong>Default: client</strong></para>
		/// </summary>
		/// <example>full</example>
		[JsonProperty("parse")]
		public string Parse { get; set; }

		/// <summary>
		/// New text for the message, using the default formatting rules. It's not required when presenting <see cref="Blocks"/> or <see cref="Attachments"/>.
		/// </summary>
		/// <example>Hello world</example>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Emoji to use as the icon for this message. Overrides <see cref="IconUrl"/>.
		/// Must be used in conjunction with <see cref="AsUser"/> set to "false", otherwise ignored.
		/// This argument may not be used with newer bot tokens.
		/// </summary>
		/// <example>:chart_with_upwards_trend:</example>
		[JsonProperty("icon_emoji")]
		public string IconEmoji { get; set; }

		/// <summary>
		/// URL to an image to use as the icon for this message.
		/// Must be used in conjunction with <see cref="AsUser"/> set to "false", otherwise ignored.
		/// This argument may not be used with newer bot tokens.
		/// </summary>
		/// <example>http://lorempixel.com/48/48</example>
		[JsonProperty("icon_url")]
		public Uri IconUrl { get; set; }

		/// <summary>
		/// Used in conjunction with <see cref="ThreadTimestamp"/> and indicates whether reply should be made visible to everyone in the channel or conversation.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[JsonProperty("reply_broadcast")]
		public bool? ReplyBroadcast { get; set; }

		/// <summary>
		/// Provide another message's "ts" value to make this message a reply. Avoid using a reply's "ts" value; use its parent instead.
		/// </summary>
		/// <example>1234567890.123456</example>
		[JsonProperty("thread_ts")]
		public string ThreadTimestamp { get; set; }

		/// <summary>
		/// Pass "true" to enable unfurling of primarily text-based content.
		/// </summary>
		/// <example>true</example>
		[JsonProperty("unfurl_links")]
		public bool? UnfurlLinks { get; set; }

		/// <summary>
		/// Pass "false" to disable unfurling of media content.
		/// </summary>
		/// <example>false</example>
		[JsonProperty("unfurl_media")]
		public bool? UnfurlMedia { get; set; }

		/// <summary>
		/// Set your bot's user name. Must be used in conjunction with <see cref="AsUser"/> set to "false", otherwise ignored.
		/// </summary>
		/// <example>My Bot</example>
		[JsonProperty("username")]
		public string Username { get; set; }
	}
}