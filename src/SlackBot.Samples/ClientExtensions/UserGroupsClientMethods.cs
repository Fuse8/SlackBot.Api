using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class UserGroupsClientMethods
	{
		public static async Task<UserGroupObjectResponse> CreateUserGroupAsync(SlackClient slackClient, string channelName)
		{
			var channelId = await ConversationsClientMethods.GetChannelIdAsync(slackClient, channelName);

			return await slackClient.UserGroups.CreateAsync("Test group", "test-group", channelId);
		}
		
		public static async Task<UserGroupObjectResponse> DisableUserGroupAsync(SlackClient slackClient, string channelName)
		{
			var createUserGroupResponse = await CreateUserGroupAsync(slackClient, channelName);

			return await slackClient.UserGroups.DisableAsync(createUserGroupResponse.UserGroup.Id);
		}
		
		public static async Task<UserGroupObjectResponse> EnableUserGroupAsync(SlackClient slackClient, string channelName)
		{
			var disableUserGroupResponse = await DisableUserGroupAsync(slackClient, channelName);

			return await slackClient.UserGroups.EnableAsync(disableUserGroupResponse.UserGroup.Id);
		}
		
		public static async Task<UserGroupListResponse> GetUserGroupListAsync(SlackClient slackClient, string channelName)
		{
			await CreateUserGroupAsync(slackClient, channelName);

			return await slackClient.UserGroups.ListAsync(true, true, true);
		}
		
		public static async Task<UserGroupObjectResponse> UpdateUserGroupAsync(SlackClient slackClient, string channelName)
		{
			var createUserGroupResponse = await CreateUserGroupAsync(slackClient, channelName);

			var userGroupToUpdate = new UserGroupToUpdate(createUserGroupResponse.UserGroup.Id)
			{
				Name = "New test group",
				Handle = "new-test-group",
				Description = "New user group description"
			};

			return await slackClient.UserGroups.UpdateAsync(userGroupToUpdate);
		}
	}
}