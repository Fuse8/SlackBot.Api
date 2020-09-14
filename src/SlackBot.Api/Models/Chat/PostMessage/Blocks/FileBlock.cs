using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.Models.Chat.PostMessage.Blocks
{
	public class FileBlock : BlockBase
	{
		protected override string SectionType => "file";

		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }
	}
}