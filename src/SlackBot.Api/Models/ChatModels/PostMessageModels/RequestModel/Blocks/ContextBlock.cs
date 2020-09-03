using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
{
	public class ContextBlock : BlockBase
	{
		protected override string SectionType => "context";
		
		[JsonProperty("elements")]
		public SectionBase[] Elements { get; set; } 

		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}