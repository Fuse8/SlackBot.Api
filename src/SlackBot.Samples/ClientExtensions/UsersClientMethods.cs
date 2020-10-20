using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class UsersClientMethods
	{
		public static Task<ConversationObjectListResponse> GetUserConversationsAsync(SlackClient slackClient)
			=> slackClient.Users.ConversationsAsync("public_channel,private_channel,mpim,im");

		public static Task<UserPresenceResponse> GetUserPresenceAsync(SlackClient slackClient, string userId)
			=> slackClient.Users.GetPresenceAsync(userId);

		public static Task<UserResponse> GetUserInfoAsync(SlackClient slackClient, string userId)
			=> slackClient.Users.InfoAsync(userId);

		public static Task<UserListResponse> GetUserListAsync(SlackClient slackClient)
			=> slackClient.Users.ListAsync();

		public static async Task<UserResponse> GetUserByEmailAsync(SlackClient slackClient, string userId)
		{
			var userInfoResponse = await GetUserInfoAsync(slackClient, userId);
			
			return await slackClient.Users.LookupByEmailAsync(userInfoResponse.User.Profile.Email);
		}

		public static Task<SlackBaseResponse> SetUserPresenceAsync(SlackClient slackClient)
			=> slackClient.Users.SetPresenceAsync("auto");
	}
}