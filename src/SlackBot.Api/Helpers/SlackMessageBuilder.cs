using System;
using System.Collections.Generic;
using System.Linq;
using SlackBot.Api.Enums;
using SlackBot.Api.Extensions;

namespace SlackBot.Api.Helpers
{
	public class SlackMessageBuilder
	{
		private const string DefaultSeparator = "";
		
		private readonly SlackMessage _slackMessage;
		private readonly List<Attachment> _attachments;
		private readonly List<BlockBase> _blocks;
		private string _text;
		
		public SlackMessageBuilder(string channel)
		{
			_slackMessage = new SlackMessage(channel);
			_attachments = new List<Attachment>();
			_blocks = new List<BlockBase>();
		}
		
		public static SlackMessageBuilder CreateBuilder(string channel)
			=> new SlackMessageBuilder(channel);
		
		public static implicit operator SlackMessage(SlackMessageBuilder slackMessageBuilder)
			=> slackMessageBuilder.CreateMessage();
		
		public SlackMessage CreateMessage()
		{
			if (_blocks.Any())
			{
				_slackMessage.Blocks = _blocks;
			}
			
			if (_attachments.Any())
			{
				_slackMessage.Attachments = _attachments;
			}

			if (!string.IsNullOrEmpty(_text))
			{
				_slackMessage.Text = _text;
			}
				
			return _slackMessage;
		}

		public SlackMessageBuilder Reply(string threadTimestamp, bool? replyBroadcast = null)
		{
			_slackMessage.ThreadTimestamp = threadTimestamp;
			_slackMessage.ReplyBroadcast = replyBroadcast;
			
			return this;
		}

		public SlackMessageBuilder PublicChannelMention(string channelId, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.PublicChannelMention(channelId), separator);

		public SlackMessageBuilder UserGroupMention(string groupId, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.UserGroupMention(groupId), separator);

		public SlackMessageBuilder ChannelMention(SlackMention slackMention, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.ChannelMention(slackMention), separator);

		public SlackMessageBuilder UserMention(string userId, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.UserMention(userId), separator);

		public SlackMessageBuilder UserMentions(IEnumerable<string> userIds, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.UserMentions(userIds), separator);
		
		public SlackMessageBuilder Text(string text, string separator = DefaultSeparator)
			=> TextInternal(text, separator);

		public SlackMessageBuilder BoldText(string text, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.Bold(text), separator);

		public SlackMessageBuilder InlineCodeText(string text, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.InlineCode(text), separator);

		public SlackMessageBuilder CodeBlock(string text, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.CodeBlock(text), separator);

		public SlackMessageBuilder ItalicText(string text, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.Italic(text), separator);

		public SlackMessageBuilder StrikeText(string text, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.Strike(text), separator);

		public SlackMessageBuilder QuotedText(string text, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.Quoted(text), separator);

		public SlackMessageBuilder ListText(params string[] textList)
			=> TextInternal(SlackMessageTextHelper.List(textList), string.Empty);

		public SlackMessageBuilder LinkText(Uri url, string label = null, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.Link(url, label), separator);

		public SlackMessageBuilder EmailLinkText(string email, string senderName = null, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.EmailLink(email, senderName), separator);

		public SlackMessageBuilder LinkText(string url, string label = null, string separator = DefaultSeparator)
			=> TextInternal(SlackMessageTextHelper.Link(url, label), separator);

		public SlackMessageBuilder Date(long timestamp, string formatString, string fallbackText, Uri link = null, string separator = DefaultSeparator)
		=> TextInternal(SlackMessageTextHelper.Date(timestamp, formatString, fallbackText, link), separator);

		public SlackMessageBuilder LineBreak()
			=> TextInternal(SlackMessageTextHelper.LineBreak, string.Empty);

		public SlackMessageBuilder Attachments(params Attachment[] attachments)
		{
			_attachments.AddRangeIfNotNull(attachments);

			return this;
		}

		public SlackMessageBuilder Blocks(params BlockBase[] blocks)
		{
			_blocks.AddRangeIfNotNull(blocks);

			return this;
		}

		private SlackMessageBuilder TextInternal(string text, string separator)
		{
			if (!string.IsNullOrEmpty(_text))
			{
				_text += $"{separator}{text}";
			}
			else
			{
				_text = text;
			}

			return this;
		}
	}
}