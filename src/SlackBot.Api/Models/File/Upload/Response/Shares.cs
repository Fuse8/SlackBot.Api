using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.File.Upload.Response
{
	public class Shares
	{
		[JsonPropertyName("private")]
		public Dictionary<string, ShareItem[]> Private { get; set; }
        
		[JsonPropertyName("public")]
		public Dictionary<string, ShareItem[]> Public { get; set; }
	}
}