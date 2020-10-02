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
		public Task<UserGroupObjectResponse> CreateAsync(UserGroupToCreate userGroup)
			=> SendPostFormUrlEncodedAsync<UserGroupToCreate, UserGroupObjectResponse>("create", userGroup);

		/// <summary>
		/// Disable an existing User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> DisableAsync(UserGroupToDisable userGroupToDisable)
			=> SendPostFormUrlEncodedAsync<UserGroupToDisable, UserGroupObjectResponse>("disable", userGroupToDisable);

		/// <summary>
		/// Enable a User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> EnableAsync(UserGroupToEnable userGroupToEnable)
			=> SendPostFormUrlEncodedAsync<UserGroupToEnable, UserGroupObjectResponse>("enable", userGroupToEnable);

		/// <summary>
		/// List all User Groups for a team.
		/// </summary>
		public Task<UserGroupListResponse> ListAsync(UserGroupListRequest userGroupListRequest)
			=> SendGetAsync<UserGroupListRequest, UserGroupListResponse>("list", userGroupListRequest);

		/// <summary>
		/// Update an existing User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> UpdateAsync(UserGroupToUpdate userGroupToUpdate)
			=> SendPostFormUrlEncodedAsync<UserGroupToUpdate, UserGroupObjectResponse>("update", userGroupToUpdate);
	}
}