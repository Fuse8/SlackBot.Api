using System;
using System.Collections.Generic;
using System.Linq;
using SlackBot.Api.Enums;
using SlackBot.Api.Extensions;

namespace SlackBot.Api.Helpers
{
	public class MessageBuilder
	{
		private const string DefaultSeparator = "";
		
		private readonly SlackMessage _slackMessage;
		private readonly List<Attachment> _attachments;
		private readonly List<BlockBase> _blocks;
		private string _text;
		
		public MessageBuilder(string channel)
		{
			_slackMessage = new SlackMessage(channel);
			_attachments = new List<Attachment>();
			_blocks = new List<BlockBase>();
		}
		
		public static MessageBuilder CreateBuilder(string channel)
			=> new MessageBuilder(channel);
		
		public static implicit operator SlackMessage(MessageBuilder messageBuilder)
			=> messageBuilder.CreateMessage();
		
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

		public MessageBuilder Reply(string threadTimestamp, bool? replyBroadcast = null)
		{
			_slackMessage.ThreadTimestamp = threadTimestamp;
			_slackMessage.ReplyBroadcast = replyBroadcast;
			
			return this;
		}

		public MessageBuilder PublicChannelMention(string channelId, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.PublicChannelMention(channelId), separator);

		public MessageBuilder UserGroupMention(string groupId, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.UserGroupMention(groupId), separator);

		public MessageBuilder ChannelMention(SlackMention slackMention, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.ChannelMention(slackMention), separator);

		public MessageBuilder UserMention(string userId, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.UserMention(userId), separator);

		public MessageBuilder UserMentions(IEnumerable<string> userIds, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.UserMentions(userIds), separator);
		
		public MessageBuilder Text(string text, string separator = DefaultSeparator)
			=> TextInternal(text, separator);

		public MessageBuilder BoldText(string text, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.Bold(text), separator);

		public MessageBuilder InlineCodeText(string text, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.InlineCode(text), separator);

		public MessageBuilder CodeBlock(string text, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.CodeBlock(text), separator);

		public MessageBuilder ItalicText(string text, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.Italic(text), separator);

		public MessageBuilder StrikeText(string text, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.Strike(text), separator);

		public MessageBuilder QuotedText(string text, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.Quoted(text), separator);

		public MessageBuilder ListText(params string[] textList)
			=> TextInternal(TextHelper.List(textList), string.Empty);

		public MessageBuilder LinkText(Uri url, string label = null, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.Link(url, label), separator);

		public MessageBuilder EmailLinkText(string email, string senderName = null, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.EmailLink(email, senderName), separator);

		public MessageBuilder LinkText(string url, string label = null, string separator = DefaultSeparator)
			=> TextInternal(TextHelper.Link(url, label), separator);

		public MessageBuilder Date(long timestamp, string formatString, string fallbackText, Uri link = null, string separator = DefaultSeparator)
		=> TextInternal(TextHelper.Date(timestamp, formatString, fallbackText, link), separator);

		public MessageBuilder LineBreak()
			=> TextInternal(TextHelper.LineBreak, string.Empty);

		public MessageBuilder Attachments(params Attachment[] attachments)
		{
			_attachments.AddRangeIfNotNull(attachments);

			return this;
		}

		public MessageBuilder Blocks(params BlockBase[] blocks)
		{
			_blocks.AddRangeIfNotNull(blocks);

			return this;
		}

		private MessageBuilder TextInternal(string text, string separator)
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