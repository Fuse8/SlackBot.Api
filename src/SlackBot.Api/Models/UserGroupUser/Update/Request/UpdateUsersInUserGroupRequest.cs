using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.UserGroupUser.Update.Request
{
	public class UpdateUsersInUserGroupRequest
	{
		public UpdateUsersInUserGroupRequest()
		{
		}

		public UpdateUsersInUserGroupRequest(string userGroupId, string userIds, bool? includeUserCount = null)
		{
			UserGroupId = userGroupId;
			UserIds = userIds;
			IncludeUserCount = includeUserCount;
		}

		/// <summary>
		/// The encoded ID of the User Group to update.
		/// </summary>
		/// <example>S06045678</example>
		[FormPropertyName("usergroup")]
		public string UserGroupId { get; set; }

		/// <summary>
		/// A comma separated string of encoded user IDs that represent the entire list of users for the User Group.
		/// </summary>
		/// <example>U060R4BJ4,U06012345</example>
		[FormPropertyName("users")]
		public string UserIds { get; set; }

		/// <summary>
		/// Include the number of users in the User Group.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_count")]
		public bool? IncludeUserCount { get; set; }
	}
}