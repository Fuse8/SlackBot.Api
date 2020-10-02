using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class UserGroupListRequest
	{
		public UserGroupListRequest()
		{
		}

		public UserGroupListRequest(bool? includeUsers, bool? includeDisabledGroups = null, bool? includeUserCount = null)
		{
			IncludeUsers = includeUsers;
			IncludeDisabledGroups = includeDisabledGroups;
			IncludeUserCount = includeUserCount;
		}

		/// <summary>
		/// Include the number of users in each User Group.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_count")]
		public bool? IncludeUserCount { get; set; }
		
		/// <summary>
		/// Include disabled User Groups.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_disabled")]
		public bool? IncludeDisabledGroups { get; set; }
		
		/// <summary>
		/// Include the list of users for each User Group.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_users")]
		public bool? IncludeUsers { get; set; }
	}
}