using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models.GeneralObjects.UserGroup;
using SlackBot.Api.Models.UserGroup.Create.Request;
using SlackBot.Api.Models.UserGroup.Disable.Request;
using SlackBot.Api.Models.UserGroup.Enable.Request;
using SlackBot.Api.Models.UserGroup.List.Request;
using SlackBot.Api.Models.UserGroup.List.Response;
using SlackBot.Api.Models.UserGroup.Update.Request;

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