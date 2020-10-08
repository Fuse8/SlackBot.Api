using System;
using System.Linq;

namespace SlackBot.Api.Helpers
{
	public static class TextHelper
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

		private static string FormatText(string text, string formatSymbols)
			=> $"{formatSymbols}{text}{formatSymbols}";
	}
}