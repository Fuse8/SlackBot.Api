using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage.Contracts;
using SlackBot.Api.Clients.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Clients.PostMessage.Blocks
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