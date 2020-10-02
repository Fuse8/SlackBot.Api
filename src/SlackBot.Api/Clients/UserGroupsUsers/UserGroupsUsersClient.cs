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

		/// <summary>
		/// List all users in a User Group.
		/// </summary>
		public Task<UserGroupUserListResponse> ListAsync(UserGroupUserListRequest userGroupUserListRequest)
			=> SendGetAsync<UserGroupUserListRequest, UserGroupUserListResponse>("list", userGroupUserListRequest);

		/// <summary>
		/// Update the list of users for a User Group.
		/// </summary>
		public Task<UserGroupResponse> UpdateAsync(UpdateUsersInUserGroupRequest updateUsersInUserGroupRequest)
			=> SendPostFormUrlEncodedAsync<UpdateUsersInUserGroupRequest, UserGroupResponse>("update", updateUsersInUserGroupRequest);
	}
}