using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class UserGroupsUsersClient : SlackClientBase
	{
		public UserGroupsUsersClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "usergroups.users";

		/// <inheritdoc cref="ListAsync(UserGroupUserListRequest)"/>
		public Task<UserGroupUserListResponse> ListAsync(string userGroupId, bool? includeDisabledUserGroup = null)
			=> ListAsync(new UserGroupUserListRequest(userGroupId, includeDisabledUserGroup));

		/// <summary>
		/// List all users in a User Group.
		/// </summary>
		public Task<UserGroupUserListResponse> ListAsync(UserGroupUserListRequest userGroupUserListRequest)
			=> SendGetAsync<UserGroupUserListRequest, UserGroupUserListResponse>("list", userGroupUserListRequest);

		/// <inheritdoc cref="UpdateAsync(UpdateUsersInUserGroupRequest)"/>
		public Task<UserGroupObjectResponse> UpdateAsync(string userGroupId, string userIds, bool? includeUserCount = null)
			=> UpdateAsync(new UpdateUsersInUserGroupRequest(userGroupId, userIds, includeUserCount));

		/// <summary>
		/// Update the list of users for a User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> UpdateAsync(UpdateUsersInUserGroupRequest updateUsersInUserGroupRequest)
			=> SendPostFormUrlEncodedAsync<UpdateUsersInUserGroupRequest, UserGroupObjectResponse>("update", updateUsersInUserGroupRequest);
	}
}