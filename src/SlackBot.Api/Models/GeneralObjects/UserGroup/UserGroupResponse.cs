using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.UserGroup
{
	public class UserGroupResponse
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("team_id")]
		public string TeamId { get; set; }

		[JsonProperty("is_usergroup")]
		public bool IsUserGroup { get; set; }

		[JsonProperty("is_subteam")]
		public bool? IsSubTeam { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("handle")]
		public string Handle { get; set; }

		[JsonProperty("is_external")]
		public bool IsExternal { get; set; }

		[JsonProperty("date_create")]
		public long DateCreateTimestamp { get; set; }

		[JsonProperty("date_update")]
		public long DateUpdateTimestamp { get; set; }

		[JsonProperty("date_delete")]
		public long DateDeleteTimestamp { get; set; }

		[JsonProperty("auto_type")]
		public string AutoType { get; set; }

		[JsonProperty("auto_provision")]
		public bool? IsAutoProvision { get; set; }

		[JsonProperty("enterprise_subteam_id")]
		public string EnterpriseSubteamId { get; set; }

		[JsonProperty("created_by")]
		public string CreatedById { get; set; }

		[JsonProperty("updated_by")]
		public string UpdatedById { get; set; }

		[JsonProperty("deleted_by")]
		public string DeletedById { get; set; }

		[JsonProperty("prefs")]
		public UserGroupPreferences Preferences { get; set; }

		[JsonProperty("users")]
		public List<string> UserIds { get; set; }

		[JsonProperty("user_count")]
		public long UserCount { get; set; }

		[JsonProperty("channel_count")]
		public long? ChannelCount { get; set; }
	}
}