using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.FileModels.UploadModels.ResponseModels
{
	public class Shares
	{
		[JsonProperty("private")]
		public Dictionary<string, ShareItem[]> Private { get; set; }
        
		[JsonProperty("public")]
		public Dictionary<string, ShareItem[]> Public { get; set; }
	}
}