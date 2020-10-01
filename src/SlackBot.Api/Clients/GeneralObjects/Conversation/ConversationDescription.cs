using Newtonsoft.Json;

namespace SlackBot.Api.Clients.GeneralObjects.Conversation
{
	public class ConversationDescription
	{
		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("creator")]
		public string Creator { get; set; }

		[JsonProperty("last_set")]
		public long LastSetTimestamp { get; set; }
	}
}