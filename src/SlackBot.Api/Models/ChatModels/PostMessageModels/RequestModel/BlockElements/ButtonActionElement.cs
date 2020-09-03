using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Enums;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements
{
	public class ButtonActionElement : ActionElementBase
	{
		protected override string SectionType => "button";
		
		[JsonProperty("text")]
		public TextSectionBase Text { get; set; }
		
		[JsonProperty("action_id")]
		public string ActionId { get; set; }

		[JsonProperty("url")]
		public Uri Url { get; set; }
		
		[JsonProperty("value")]
		public string Value { get; set; }
		
		[JsonProperty("style")]
		public StyleType? Style { get; set; }
		
		[JsonProperty("confirm")]
		public ConfirmSection Confirm { get; set; }
	}
}