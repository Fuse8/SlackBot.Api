﻿using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements
{
	public abstract class ActionElementBase : ObjectWithType
	{
		[JsonProperty("action_id")]
		public string ActionId { get; set; }
	}
}