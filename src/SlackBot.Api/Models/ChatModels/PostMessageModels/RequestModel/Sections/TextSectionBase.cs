using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections
{
	public abstract class TextSectionBase : SectionBase
	{
		[JsonProperty("text")]
		public string Text { get; set; }
		
		[JsonProperty("verbatim")]
		public bool?  Verbatim { get; set; }
	}
}