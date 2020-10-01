using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public abstract class ClassicPaginationResponseBase : SlackBaseResponse
	{
		[JsonProperty("paging")]
		public ClassicPaginationData Paging { get; set; }
	}
}