using Newtonsoft.Json;

namespace SlackBot.Api.Models.UserModels.ConversationModels.ResponseModels
{
	public class Purpose
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("creator")]
		public string Creator { get; set; }

		[JsonProperty("last_set")]
		public long LastSet { get; set; }
	}
}