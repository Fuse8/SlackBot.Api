using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections
{
	public class OptionGroupSection
	{
		[JsonProperty("label")]
		public PlainTextSection Label { get; set; }
		
		[JsonProperty("options")]
		public OptionSection[] Options { get; set; }
	}
}