using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class TeamProfileClient : SlackClientBase
	{
		public TeamProfileClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "team.profile";

		/// <inheritdoc cref="GetAsync(TeamProfileRequest)"/>
		public Task<TeamProfileResponse> GetAsync(TeamFieldVisibilityType? visibility = null)
			=> GetAsync(new TeamProfileRequest(visibility));

		/// <summary>
		/// Retrieve a team's profile.
		/// </summary>
		public Task<TeamProfileResponse> GetAsync(TeamProfileRequest teamProfileRequest)
			=> SendGetAsync<TeamProfileRequest, TeamProfileResponse>("get", teamProfileRequest);
	}
}