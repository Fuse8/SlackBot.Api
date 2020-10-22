using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class UsersProfileClientMethods
	{
		public static Task<UserProfileResponse> GetUserProfileAsync(SlackClient slackClient, string userId)
			=> slackClient.UsersProfile.GetAsync(userId, true);
	}
}