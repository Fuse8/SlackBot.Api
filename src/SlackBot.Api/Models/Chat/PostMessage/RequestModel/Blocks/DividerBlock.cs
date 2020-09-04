using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
{
	public class DividerBlock : BlockBase
	{
		protected override string SectionType => "divider";
		
		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}