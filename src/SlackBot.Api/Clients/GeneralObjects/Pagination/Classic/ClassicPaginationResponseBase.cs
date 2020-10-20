using Newtonsoft.Json;

namespace SlackBot.Api
{
	public abstract class ClassicPaginationResponseBase : SlackBaseResponse
	{
		[JsonProperty("paging")]
		public ClassicPaginationData Paging { get; set; }
	}
}