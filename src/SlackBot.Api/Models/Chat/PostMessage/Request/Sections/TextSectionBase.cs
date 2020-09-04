using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Sections
{
	public abstract class TextSectionBase : SectionBase
	{
		[JsonProperty("text")]
		public string Text { get; set; }
		
		[JsonProperty("verbatim")]
		public bool?  Verbatim { get; set; }
	}
}