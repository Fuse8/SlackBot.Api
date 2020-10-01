using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class TeamInfo
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("domain")]
		public string Domain { get; set; }

		[JsonProperty("email_domain")]
		public string EmailDomain { get; set; }

		[JsonProperty("icon")]
		public TeamIcons Icons { get; set; }

		[JsonProperty("enterprise_id")]
		public string EnterpriseId { get; set; }

		[JsonProperty("enterprise_name")]
		public string EnterpriseName { get; set; }
	}
}