using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models
{
	public class Shares
	{
		[JsonPropertyName("private")]
		public Dictionary<string, SharesItem[]> Private { get; set; }
        
		[JsonPropertyName("public")]
		public Dictionary<string, SharesItem[]> Public { get; set; }
	}
}