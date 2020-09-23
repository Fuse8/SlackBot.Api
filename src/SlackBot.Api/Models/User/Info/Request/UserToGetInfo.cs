using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.User.Info.Request
{
	public class UserToGetInfo
	{
		public UserToGetInfo()
		{
		}

		public UserToGetInfo(string userId)
		{
			UserId = userId;
		}

		/// <summary>
		/// User to get info on.
		/// </summary>
		/// <example>W1234567890</example>
		[FormPropertyName("user")]
		public string UserId { get; set; }

		/// <summary>
		/// Set this to "true" to receive the locale for this user.
		/// <para><strong>Default: false</strong></para> 
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_locale")]
		public bool? IncludeLocale { get; set; }
	}
}