using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Pagination.Classic
{
	public abstract class ClassicPaginationResponseBase : SlackBaseResponse
	{
		[JsonProperty("paging")]
		public ClassicPaginationData Paging { get; set; }
	}
}