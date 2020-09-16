using Newtonsoft.Json;

namespace SlackBot.Api.Models
{
	public abstract class SlackResponseBase
	{
		[JsonProperty("ok")]
		public bool Ok { get; set; }
	}
}