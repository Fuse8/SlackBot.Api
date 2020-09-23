using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.User
{
	public class SlackUser
	{
		[JsonProperty("id")]
		public string Id { get; set; } 

		[JsonProperty("team_id")]
		public string TeamId { get; set; } 

		[JsonProperty("name")]
		public string Name { get; set; } 

		[JsonProperty("deleted")]
		public bool IsDeleted { get; set; } 

		[JsonProperty("color")]
		public string Color { get; set; } 

		[JsonProperty("real_name")]
		public string RealName { get; set; } 

		[JsonProperty("tz")]
		public string Timezone { get; set; } 

		[JsonProperty("tz_label")]
		public string TimezoneLabel { get; set; } 

		[JsonProperty("tz_offset")]
		public int TimezoneOffset { get; set; } 

		[JsonProperty("profile")]
		public UserProfile Profile { get; set; } 

		[JsonProperty("is_admin")]
		public bool IsAdmin { get; set; } 

		[JsonProperty("is_owner")]
		public bool IsOwner { get; set; } 

		[JsonProperty("is_primary_owner")]
		public bool IsPrimaryOwner { get; set; } 

		[JsonProperty("is_restricted")]
		public bool IsRestricted { get; set; } 

		[JsonProperty("is_ultra_restricted")]
		public bool IsUltraRestricted { get; set; } 

		[JsonProperty("is_bot")]
		public bool IsBot { get; set; } 

		[JsonProperty("is_stranger")]
		public bool? IsStranger { get; set; } 

		[JsonProperty("updated")]
		public long UpdatedTimestamp { get; set; } 

		[JsonProperty("is_app_user")]
		public bool IsAppUser { get; set; } 

		[JsonProperty("is_invited_user")]
		public bool? IsInvitedUser { get; set; } 

		[JsonProperty("has_2fa")]
		public bool? HasTwoFactorAuthentication { get; set; } 

		[JsonProperty("locale")]
		public string Locale { get; set; }
	}
}