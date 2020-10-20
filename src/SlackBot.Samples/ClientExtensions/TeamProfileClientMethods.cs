using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class TeamProfileClientMethods
	{
		public static Task<TeamProfileResponse> GetTeamProfileAsync(SlackClient slackClient)
			=> slackClient.TeamProfile.GetAsync(TeamFieldVisibilityType.Visible);
	}
}