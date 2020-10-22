using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class UserGroupsUsersClientMethods
	{
		public static async Task<UserGroupUserListResponse> GetUserGroupUserListAsync(SlackClient slackClient, string channelName, string userId)
		{
			var updateUsersInUserGroupResponse = await UpdateUsersInUserGroupAsync(slackClient, channelName, userId);

			return await slackClient.UserGroupsUsers.ListAsync(updateUsersInUserGroupResponse.UserGroup.Id);
		}
		
		public static async Task<UserGroupObjectResponse> UpdateUsersInUserGroupAsync(SlackClient slackClient, string channelName, string userId)
		{
			var createUserGroupResponse = await UserGroupsClientMethods.CreateUserGroupAsync(slackClient, channelName);

			var updateUsersInUserGroupRequest = new UpdateUsersInUserGroupRequest
			{
				UserGroupId = createUserGroupResponse.UserGroup.Id,
				UserIds = userId
			};

			return await slackClient.UserGroupsUsers.UpdateAsync(updateUsersInUserGroupRequest);
		}
	}
}