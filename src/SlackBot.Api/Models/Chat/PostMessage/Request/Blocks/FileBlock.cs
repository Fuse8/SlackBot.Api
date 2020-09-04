using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.Blocks
{
	public class FileBlock : BlockBase
	{
		protected override string SectionType => "file";

		[JsonProperty("block_id")]
		public string BlockId { get; set; }

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }
	}
}