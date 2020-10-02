using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserProfileObject
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("skype")]
		public string Skype { get; set; }

		[JsonProperty("real_name")]
		public string RealName { get; set; }

		[JsonProperty("real_name_normalized")]
		public string RealNameNormalized { get; set; }

		[JsonProperty("display_name")]
		public string DisplayName { get; set; }

		[JsonProperty("display_name_normalized")]
		public string DisplayNameNormalized { get; set; }

		[JsonProperty("fields")]
		public Dictionary<string, UserProfileObjectField> Fields { get; set; }

		[JsonProperty("status_text")]
		public string StatusText { get; set; }

		[JsonProperty("status_emoji")]
		public string StatusEmoji { get; set; }

		[JsonProperty("status_expiration")]
		public long StatusExpirationTimestamp { get; set; }

		[JsonProperty("avatar_hash")]
		public string AvatarHash { get; set; } 

		[JsonProperty("api_app_id")]
		public string ApiAppId { get; set; } 

		[JsonProperty("always_active")]
		public bool? IsAlwaysActive { get; set; }

		[JsonProperty("bot_id")]
		public string BotId { get; set; }

		[JsonProperty("first_name")]
		public string FirstName { get; set; }

		[JsonProperty("last_name")]
		public string LastName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("image_original")]
		public Uri ImageOriginalUrl { get; set; }

		[JsonProperty("is_custom_image")]
		public bool? IsCustomImage { get; set; }

		[JsonProperty("image_24")]
		public Uri Image24Url { get; set; }

		[JsonProperty("image_32")]
		public Uri Image32Url { get; set; }

		[JsonProperty("image_48")]
		public Uri Image48Url { get; set; }

		[JsonProperty("image_72")]
		public Uri Image72Url { get; set; }

		[JsonProperty("image_192")]
		public Uri Image192Url { get; set; }

		[JsonProperty("image_512")]
		public Uri Image512Url { get; set; }

		[JsonProperty("image_1024")]
		public Uri Image1024Url { get; set; }

		[JsonProperty("status_text_canonical")]
		public string StatusTextCanonical { get; set; }

		[JsonProperty("team")]
		public string TeamId { get; set; }
	}
}