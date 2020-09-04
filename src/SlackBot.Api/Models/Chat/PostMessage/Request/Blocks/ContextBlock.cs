using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
{
	public class ContextBlock : BlockBase
	{
		protected override string SectionType => "context";
		
		[JsonProperty("elements")]
		public IContextElement[] Elements { get; set; } 

		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}