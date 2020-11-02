using System;
using System.Collections.Generic;
using System.Linq;
using SlackBot.Api.Enums;

namespace SlackBot.Api.Helpers
{
	public static class SlackMessageTextHelper
	{
		private const string QuotedLineBreak = LineBreak + ">";
		private const string ListLineBreak = LineBreak + "• ";
		private const string LabelSeparator = "|";

		public const string LineBreak = "\n";

		public static string Bold(string text)
			=> FormatText(text, "*");

		public static string InlineCode(string text)
			=> FormatText(text, "`");

		public static string CodeBlock(string text)
			=> FormatText(text, "```");

		public static string Italic(string text)
			=> FormatText(text, "_");

		public static string Strike(string text)
			=> FormatText(text, "~");

		public static string Link(Uri url, string label = null)
			=> Link(url.ToString(), label);

		public static string EmailLink(string email, string senderName = null)
			=> Link($"mailto:{email}", senderName);

		public static string Link(string url, string label = null)
		{
			if (!string.IsNullOrEmpty(label))
			{
				url += LabelSeparator + label;
			}

			return $"<{url}>";
		}

		public static string Quoted(string text)
			=> $"{QuotedLineBreak}{text.Replace(LineBreak, QuotedLineBreak)}{LineBreak}";

		public static string List(params string[] textList)
		{
			string text = string.Empty;
			if (textList != null && textList.Any())
			{
				text = $"{ListLineBreak}{string.Join(ListLineBreak, textList)}{LineBreak}";
			}

			return text;
		}

		public static string PublicChannelMention(string channelId)
			=> SquareBrackets($"#{channelId}");

		public static string UserGroupMention(string groupId)
			=> SquareBrackets($"!subteam^{groupId}");

		public static string ChannelMention(SlackMention slackMention)
			=> SquareBrackets($"!{slackMention.ToString().ToLower()}");

		public static string UserMention(string userId)
			=> SquareBrackets($"@{userId}");

		public static string UserMentions(IEnumerable<string> userIds)
		{
			string mentions = string.Empty;

			if (userIds != null)
			{
				mentions = string.Join(" ", userIds.Select(UserMention));
			}

			return mentions;
		}

		public static string Date(long timestamp, string formatString, string fallbackText)
			=> Date(timestamp, formatString, fallbackText, (string) null);

		public static string Date(long timestamp, string formatString, string fallbackText, Uri link)
			=> Date(timestamp, formatString, fallbackText, link?.ToString());

		public static string Date(long timestamp, string formatString, string fallbackText, string link)
		{
			string dateString = string.Empty;

			if (timestamp > 0)
			{
				dateString += $"!date^{timestamp}^{formatString}";

				if (link != null)
				{
					dateString += $"^{link}";
				}

				dateString = SquareBrackets(dateString + $"|{fallbackText}");
			}

			return dateString;
		}

		private static string FormatText(string text, string formatSymbols)
			=> $"{formatSymbols}{text}{formatSymbols}";

		private static string SquareBrackets(string mention)
			=> $"<{mention}>";
	}
}