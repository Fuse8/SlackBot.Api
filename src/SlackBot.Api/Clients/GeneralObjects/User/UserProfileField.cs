using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserProfileField
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("alt")]
		public string Alt { get; set; }

		[JsonProperty("label")]
		public string Label { get; set; }
	}
}