using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class ClassicPaginationData
	{
		[JsonProperty("count")]
		public long Count { get; set; }
		
		[JsonProperty("total")]
		public long Total { get; set; }
		
		[JsonProperty("page")]
		public long Page { get; set; }
		
		[JsonProperty("pages")]
		public long Pages { get; set; }
	}
}