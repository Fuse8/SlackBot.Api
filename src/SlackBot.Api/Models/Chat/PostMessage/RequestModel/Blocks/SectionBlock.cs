using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
{
	public class SectionBlock : BlockBase
	{
		protected override string SectionType => "section";

		[JsonProperty("block_id")]
		public string BlockId { get; set; }
		
		[JsonProperty("text")]
		public TextSectionBase Text { get; set; }
		
		[JsonProperty("fields")]
		public TextSectionBase[] Fields { get; set; }

		[JsonProperty("accessory")]
		public ActionElementBase[] Accessory { get; set; }
	}
}