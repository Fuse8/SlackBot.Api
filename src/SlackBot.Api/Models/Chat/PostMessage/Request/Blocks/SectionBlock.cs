using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Request.Sections;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
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