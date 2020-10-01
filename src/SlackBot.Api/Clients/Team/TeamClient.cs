using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api.Clients
{
	public class TeamClient : SlackClientBase
	{
		public TeamClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "team";

		/// <summary>
		/// Gets information about the current team.
		/// </summary>
		public Task<TeamInfoResponse> InfoAsync(TeamInfoRequest teamInfoRequest)
			=> SendGetAsync<TeamInfoRequest, TeamInfoResponse>("info", teamInfoRequest);
	}
}