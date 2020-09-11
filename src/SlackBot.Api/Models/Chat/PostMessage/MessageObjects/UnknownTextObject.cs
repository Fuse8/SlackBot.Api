﻿using System.Collections.Generic;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	/// <summary>
	/// Do not use in request to the slack.
	/// This type is only used to parse unknown models in Slack responses   
	/// </summary>
	public class UnknownTextObject : TextObjectBase, IUnknownObjectWithType
	{
		protected override string SectionType => null;
		
		public Dictionary<string, object> Properties { get; set; }
	}
}