using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class UserGroupsClient : SlackClientBase
	{
		public UserGroupsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "usergroups";

		/// <summary>
		/// Create a User Group.
		/// </summary>
		public Task<UserGroupResponse> CreateAsync(UserGroupToCreate userGroup)
			=> SendPostFormUrlEncodedAsync<UserGroupToCreate, UserGroupResponse>("create", userGroup);

		/// <summary>
		/// Disable an existing User Group.
		/// </summary>
		public Task<UserGroupResponse> DisableAsync(UserGroupToDisable userGroupToDisable)
			=> SendPostFormUrlEncodedAsync<UserGroupToDisable, UserGroupResponse>("disable", userGroupToDisable);

		/// <summary>
		/// Enable a User Group.
		/// </summary>
		public Task<UserGroupResponse> EnableAsync(UserGroupToEnable userGroupToEnable)
			=> SendPostFormUrlEncodedAsync<UserGroupToEnable, UserGroupResponse>("enable", userGroupToEnable);

		/// <summary>
		/// List all User Groups for a team.
		/// </summary>
		public Task<UserGroupListResponse> ListAsync(UserGroupListRequest userGroupListRequest)
			=> SendGetAsync<UserGroupListRequest, UserGroupListResponse>("list", userGroupListRequest);

		/// <summary>
		/// Update an existing User Group.
		/// </summary>
		public Task<UserGroupResponse> UpdateAsync(UserGroupToUpdate userGroupToUpdate)
			=> SendPostFormUrlEncodedAsync<UserGroupToUpdate, UserGroupResponse>("update", userGroupToUpdate);
	}
}