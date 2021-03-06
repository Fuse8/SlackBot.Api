﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public abstract class MessageBase
	{
		protected MessageBase()
		{
		}

		protected MessageBase(string channelIdOrName, string text, List<Attachment> attachments, List<BlockBase> blocks)
		{
			ChannelIdOrName = channelIdOrName;
			Text = text;
			Attachments = attachments;
			Blocks = blocks;
		}

		/// <summary>
		/// Channel, private group, or IM channel to send message to. Can be an encoded ID, or a name.
		/// </summary>
		/// <example>C1234567890</example>
		[JsonProperty("channel")]
		public string ChannelIdOrName { get; set; }

		/// <summary>
		/// If you are using <see cref="Blocks"/>, this is used as a fallback string to display in notifications.
		/// If you aren't, this is the main body text of the message. It can be formatted as plain text, or with mrkdwn.
		/// The <see cref="Text"/> field is not enforced as required when using <see cref="Blocks"/> or <see cref="Attachments"/>
		/// </summary>
		/// <example>Hello world</example>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Pass "true" to post the message as the authed user, instead of as a bot.
		/// This argument may not be used with newer bot tokens.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[JsonProperty("as_user")]
		public bool? AsUser { get; set; }

		/// <summary>
		/// A JSON-based array of structured attachments, presented as a URL-encoded string.
		/// </summary>
		/// <example>[{"pretext": "pre-hello", "text": "text-world"}]</example>
		[JsonProperty("attachments")]
		public List<Attachment> Attachments { get; set; }

		/// <summary>
		/// A JSON-based array of structured blocks, presented as a URL-encoded string.
		/// </summary>
		/// <example>[{"type": "section", "text": {"type": "plain_text", "text": "Hello world"}}]</example>
		[JsonProperty("blocks")]
		public List<BlockBase> Blocks { get; set; }

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
		/// Find and link channel names and usernames.
		/// </summary>
		/// <example>true</example>
		[JsonProperty("link_names")]
		public bool? LinkNames { get; set; }

		/// <summary>
		/// Change how messages are treated.
		/// <para><strong>Default: none</strong></para>
		/// </summary>
		/// <example>full</example>
		[JsonProperty("parse")]
		public string Parse { get; set; }

		/// <summary>
		/// Provide another message's "ts" value to make this message a reply. Avoid using a reply's "ts" value; use its parent instead.
		/// </summary>
		/// <example>1234567890.123456</example>
		[JsonProperty("thread_ts")]
		public string ThreadTimestamp { get; set; }

		/// <summary>
		/// Set your bot's user name. Must be used in conjunction with <see cref="AsUser"/> set to "false", otherwise ignored.
		/// </summary>
		/// <example>My Bot</example>
		[JsonProperty("username")]
		public string Username { get; set; }
	}
}