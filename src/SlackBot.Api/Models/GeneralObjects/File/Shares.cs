using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.File
{
	public class Shares
	{
		[JsonProperty("private")]
		public Dictionary<string, List<ShareItem>> Private { get; set; }

		[JsonProperty("public")]
		public Dictionary<string, List<ShareItem>> Public { get; set; }
	}
}