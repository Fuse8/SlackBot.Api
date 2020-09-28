using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects
{
	public class SlackBaseResponse
	{
		[JsonProperty("ok")]
		public bool Ok { get; set; }
	}
}