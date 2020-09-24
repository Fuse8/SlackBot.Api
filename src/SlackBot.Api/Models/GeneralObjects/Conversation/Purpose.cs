using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Conversation
{
	public class Purpose
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("creator")]
		public string Creator { get; set; }

		[JsonProperty("last_set")]
		public long LastSetTimestamp { get; set; }
	}
}