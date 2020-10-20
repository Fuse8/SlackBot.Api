using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class TeamClientMethods
	{
		public static Task<TeamInfoResponse> GetTeamInfoAsync(TeamClient teamClient)
			=> teamClient.InfoAsync();
	}
}