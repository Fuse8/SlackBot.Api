using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class ContextBlock : BlockBase
	{
		protected override string SectionType => "context";

		[JsonProperty("elements")]
		public IContextElement[] Elements { get; set; }
	}
}