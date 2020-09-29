using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class ContextBlock : BlockBase
	{
		protected override string SectionType => "context";

		/// <summary>
		/// An array of "image elements" and "text objects". Maximum number of <strong>items is 10</strong>.
		/// </summary>
		[JsonProperty("elements")]
		public List<IContextElement> Elements { get; set; }
	}
}