using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects
{
	public class WarningResponseMetadata
	{
		[JsonProperty("warnings")]
		public string[] Warnings { get; set; }
	}
}