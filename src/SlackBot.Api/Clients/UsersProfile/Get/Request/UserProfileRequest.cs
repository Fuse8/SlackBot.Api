using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class UserProfileRequest
	{
		public UserProfileRequest()
		{
		}

		public UserProfileRequest(string userId, bool? includeLabels = null)
		{
			UserId = userId;
			IncludeLabels = includeLabels;
		}

		/// <summary>
		/// Include labels for each ID in custom profile fields.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_labels")]
		public bool? IncludeLabels { get; set; }

		/// <summary>
		/// User to retrieve profile info for.
		/// </summary>
		/// <example>W1234567890</example>
		[FormPropertyName("user")]
		public string UserId { get; set; }
	}
}