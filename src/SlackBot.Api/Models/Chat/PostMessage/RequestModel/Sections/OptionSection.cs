using System;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections
{
	public class OptionSection
	{
		[JsonProperty("text")]
		public TextSectionBase Text { get; set; }
		
		[JsonProperty("value")]
		public string Value { get; set; }
		
		[JsonProperty("description")]
		public PlainTextSection Description { get; set; }
		
		[JsonProperty("url")]
		public Uri Url { get; set; }
	}
}