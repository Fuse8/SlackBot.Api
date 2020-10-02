using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class FileObjectShares
	{
		[JsonProperty("private")]
		public Dictionary<string, List<FileObjectShareItem>> Private { get; set; }

		[JsonProperty("public")]
		public Dictionary<string, List<FileObjectShareItem>> Public { get; set; }
	}
}