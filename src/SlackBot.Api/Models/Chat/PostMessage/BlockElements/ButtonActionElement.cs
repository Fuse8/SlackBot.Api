using System;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Enums;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.BlockElements
{
	public class ButtonActionElement : ActionElementBase, ISectionElement, IActionElement
	{
		protected override string SectionType => "button";
		
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }
		
		[JsonProperty("url")]
		public Uri Url { get; set; }
		
		[JsonProperty("value")]
		public string Value { get; set; }
		
		[JsonProperty("style")]
		public StyleType? Style { get; set; }
	}
}