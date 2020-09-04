﻿using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.BlockElements
{
	public class CheckboxActionElement : ActionElementBase //todo use in Home tabs and  Modals
	{
		protected override string SectionType => "checkboxes";

		[JsonProperty("options")]
		public OptionObject[] Options { get; set; }

		[JsonProperty("initial_options")]
		public OptionObject[] InitialOption { get; set; }
		
		[JsonProperty("confirm")]
		public ConfirmObject Confirm { get; set; }
	}
}