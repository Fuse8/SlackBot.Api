using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients.List.Request
{
	public class UserGroupUserListRequest
	{
		public UserGroupUserListRequest()
		{
		}

		public UserGroupUserListRequest(string userGroupId, bool? includeDisabledUserGroup = null)
		{
			UserGroupId = userGroupId;
			IncludeDisabledUserGroup = includeDisabledUserGroup;
		}

		/// <summary>
		/// The encoded ID of the User Group to update.
		/// </summary>
		/// <example>S06045678</example>
		[FormPropertyName("usergroup")]
		public string UserGroupId { get; set; }

		/// <summary>
		/// Allow results that involve disabled User Groups.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_disabled")]
		public bool? IncludeDisabledUserGroup { get; set; }
	}
}