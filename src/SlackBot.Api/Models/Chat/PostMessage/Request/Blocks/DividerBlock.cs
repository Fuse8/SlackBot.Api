using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
{
	public class DividerBlock : BlockBase
	{
		protected override string SectionType => "divider";
		
		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}