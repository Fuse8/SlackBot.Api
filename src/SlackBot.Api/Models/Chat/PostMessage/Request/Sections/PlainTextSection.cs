using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Sections
{
	public class PlainTextSection : TextSectionBase
	{
		protected override string SectionType => "plain_text";
		
		[JsonProperty("emoji")]
		public bool? Emoji { get; set; }
		
		public static implicit operator PlainTextSection(string text) =>
			new PlainTextSection
			{
				Text = text
			};
	}
}