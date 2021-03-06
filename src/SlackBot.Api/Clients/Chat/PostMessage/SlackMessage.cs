﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class SlackMessage : MessageBase
	{
		public SlackMessage()
		{
		}

		public SlackMessage(string channelIdOrName, string text = null, List<Attachment> attachments = null, List<BlockBase> blocks = null)
			: base(channelIdOrName, text, attachments, blocks)
		{
		}

		/// <summary>
		/// Disable Slack markup parsing by setting to "false".
		/// <para><strong>Default: true</strong></para>
		/// </summary>
		/// <example>false</example>
		[JsonProperty("mrkdwn")]
		public bool? UseMarkdown { get; set; }

		/// <summary>
		/// Used in conjunction with <see cref="MessageBase.ThreadTimestamp"/> and indicates whether reply should be made visible to everyone in the channel or conversation.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[JsonProperty("reply_broadcast")]
		public bool? ReplyBroadcast { get; set; }

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
	}
}