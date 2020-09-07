using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class ActionBlock : BlockBase
	{
		protected override string SectionType => "actions";

		[JsonProperty("elements")]
		public IActionElement[] Elements { get; set; } 

		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}