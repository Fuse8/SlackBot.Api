using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class UserPresenceResponse : SlackBaseResponse
	{
		[JsonProperty("presence")]
		public string Presence { get; set; }

		[JsonProperty("online")]
		public bool? IsOnline { get; set; }

		[JsonProperty("auto_away")]
		public bool? IsAutoAway { get; set; }

		[JsonProperty("manual_away")]
		public bool? IsManualAway { get; set; }

		[JsonProperty("connection_count")]
		public long? ConnectionCount { get; set; }

		[JsonProperty("last_activity")]
		public long? LastActivityTimestamp { get; set; }
	}
}