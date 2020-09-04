using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
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