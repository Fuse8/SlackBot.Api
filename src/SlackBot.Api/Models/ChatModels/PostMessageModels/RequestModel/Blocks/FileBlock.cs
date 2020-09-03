using Newtonsoft.Json;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Blocks
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