using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class ActionBlock : BlockBase
	{
		protected override string SectionType => "actions";

		/// <summary>
		/// An array of interactive element objects - "buttons", "select menus", "overflow menus", or "date pickers".
		/// There is a maximum of <strong>5 elements in each action block</strong>.
		/// </summary>
		[JsonProperty("elements")]
		public List<IActionElement> Elements { get; set; }
	}
}