using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class TeamClient : SlackClientBase
	{
		public TeamClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "team";

		/// <inheritdoc cref="InfoAsync(TeamInfoRequest)"/>
		public Task<TeamInfoResponse> InfoAsync(string teamId = null)
			=> InfoAsync(new TeamInfoRequest(teamId));

		/// <summary>
		/// Gets information about the current team.
		/// </summary>
		public Task<TeamInfoResponse> InfoAsync(TeamInfoRequest teamInfoRequest)
			=> SendGetAsync<TeamInfoRequest, TeamInfoResponse>("info", teamInfoRequest);
	}
}