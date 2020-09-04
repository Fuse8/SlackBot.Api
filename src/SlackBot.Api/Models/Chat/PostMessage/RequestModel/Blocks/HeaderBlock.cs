using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
{
	public class HeaderBlock : BlockBase
	{
		protected override string SectionType => "header";

		[JsonProperty("block_id")]
		public string BlockId { get; set; }

		[JsonProperty("text")]
		public PlainTextSection Text { get; set; }
	}
}