using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
{
	public class ActionBlock : BlockBase
	{
		protected override string SectionType => "actions";

		[JsonProperty("elements")]
		public ActionElementBase[] Elements { get; set; } 

		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}