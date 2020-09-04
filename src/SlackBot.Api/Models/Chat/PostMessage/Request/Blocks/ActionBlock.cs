using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
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