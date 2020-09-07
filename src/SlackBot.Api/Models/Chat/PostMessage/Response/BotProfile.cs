using Newtonsoft.Json;

namespace SlackBot.Api.Models.Chat.PostMessage.Response
{
	public class BotProfile
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("deleted")]
		public bool Deleted { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("updated")]
		public long Updated { get; set; }

		[JsonProperty("app_id")]
		public string AppId { get; set; }

		[JsonProperty("icons")]
		public Icons Icons { get; set; }

		[JsonProperty("team_id")]
		public string TeamId { get; set; }
	}
}