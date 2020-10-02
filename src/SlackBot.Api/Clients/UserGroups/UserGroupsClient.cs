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

		/// <inheritdoc cref="CreateAsync(SlackUserGroup)"/>
		public Task<UserGroupObjectResponse> CreateAsync(string name, string handle = null, string channelIds = null, string description = null)
			=> CreateAsync(new SlackUserGroup(name, handle, channelIds, description));

		/// <summary>
		/// Create a User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> CreateAsync(SlackUserGroup slackUserGroup)
			=> SendPostFormUrlEncodedAsync<SlackUserGroup, UserGroupObjectResponse>("create", slackUserGroup);

		/// <inheritdoc cref="DisableAsync(UserGroupToDisable)"/>
		public Task<UserGroupObjectResponse> DisableAsync(string userGroupId, bool? includeUserCount = null)
			=> DisableAsync(new UserGroupToDisable(userGroupId, includeUserCount));

		/// <summary>
		/// Disable an existing User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> DisableAsync(UserGroupToDisable userGroupToDisable)
			=> SendPostFormUrlEncodedAsync<UserGroupToDisable, UserGroupObjectResponse>("disable", userGroupToDisable);

		/// <inheritdoc cref="EnableAsync(UserGroupToEnable)"/>
		public Task<UserGroupObjectResponse> EnableAsync(string userGroupId, bool? includeUserCount = null)
			=> EnableAsync(new UserGroupToEnable(userGroupId, includeUserCount));

		/// <summary>
		/// Enable a User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> EnableAsync(UserGroupToEnable userGroupToEnable)
			=> SendPostFormUrlEncodedAsync<UserGroupToEnable, UserGroupObjectResponse>("enable", userGroupToEnable);

		/// <inheritdoc cref="ListAsync(UserGroupListRequest)"/>
		public Task<UserGroupListResponse> ListAsync(bool? includeUsers, bool? includeDisabledGroups = null, bool? includeUserCount = null)
			=> ListAsync(new UserGroupListRequest(includeUsers, includeDisabledGroups, includeUserCount));

		/// <summary>
		/// List all User Groups for a team.
		/// </summary>
		public Task<UserGroupListResponse> ListAsync(UserGroupListRequest userGroupListRequest)
			=> SendGetAsync<UserGroupListRequest, UserGroupListResponse>("list", userGroupListRequest);

		/// <inheritdoc cref="UpdateAsync(UserGroupToUpdate)"/>
		public Task<UserGroupObjectResponse> UpdateAsync(string userGroupId, string name = null, string description = null, string channelIds = null, string handle = null)
			=> UpdateAsync(new UserGroupToUpdate(userGroupId, name, description, channelIds, handle));

		/// <summary>
		/// Update an existing User Group.
		/// </summary>
		public Task<UserGroupObjectResponse> UpdateAsync(UserGroupToUpdate userGroupToUpdate)
			=> SendPostFormUrlEncodedAsync<UserGroupToUpdate, UserGroupObjectResponse>("update", userGroupToUpdate);
	}
}