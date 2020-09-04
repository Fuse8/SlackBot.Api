using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
{
	public class SectionBlock : BlockBase
	{
		protected override string SectionType => "section";

		[JsonProperty("block_id")]
		public string BlockId { get; set; }
		
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }
		
		[JsonProperty("fields")]
		public TextObjectBase[] Fields { get; set; }

		[JsonProperty("accessory")]
		public ISectionElement Accessory { get; set; }
	}
}