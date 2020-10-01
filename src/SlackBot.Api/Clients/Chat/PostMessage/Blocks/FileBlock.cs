using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class FileBlock : BlockBase
	{
		protected override string SectionType => "file";

		/// <summary>
		/// The external unique ID for this file.
		/// </summary>
		[JsonProperty("external_id")]
		public string ExternalId { get; set; }

		/// <summary>
		/// At the moment, <see cref="Source"/> will always be "remote" for a remote file.
		/// </summary>
		[JsonProperty("source")]
		public string Source { get; set; }
	}
}