using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Pagination.Classic
{
	public abstract class PagePaginationResponseBase : SlackBaseResponse
	{
		[JsonProperty("paging")]
		public PagePaginationData Paging { get; set; }
	}
}