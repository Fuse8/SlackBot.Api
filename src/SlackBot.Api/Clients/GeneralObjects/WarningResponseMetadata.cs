using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects
{
	public class WarningResponseMetadata
	{
		[JsonProperty("warnings")]
		public List<string> Warnings { get; set; }
	}
}