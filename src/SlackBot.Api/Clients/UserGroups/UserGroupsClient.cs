using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Clients.Create.Request;
using SlackBot.Api.Clients.Disable.Request;
using SlackBot.Api.Clients.Enable.Request;
using SlackBot.Api.Clients.GeneralObjects.UserGroup;
using SlackBot.Api.Clients.List.Request;
using SlackBot.Api.Clients.List.Response;
using SlackBot.Api.Clients.Update.Request;

namespace SlackBot.Api.Clients
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