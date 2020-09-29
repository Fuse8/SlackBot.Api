using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.UserGroup
{
	public abstract class UserGroupActionRequestBase
	{
		protected UserGroupActionRequestBase()
		{
		}

		protected UserGroupActionRequestBase(string userGroupId, bool? includeUserCount)
		{
			UserGroupId = userGroupId;
			IncludeUserCount = includeUserCount;
		}

		/// <summary>
		/// The encoded ID of the User Group.
		/// </summary>
		/// <example>S06045678</example>
		[FormPropertyName("usergroup")]
		public string UserGroupId { get; set; }

		/// <summary>
		/// Include the number of users in each User Group.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_count")]
		public bool? IncludeUserCount { get; set; }
	}
}