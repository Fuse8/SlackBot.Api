using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
{
	public class HeaderBlock : BlockBase
	{
		protected override string SectionType => "header";

		[JsonProperty("block_id")]
		public string BlockId { get; set; }

		[JsonProperty("text")]
		public PlainTextObject Text { get; set; }
	}
}