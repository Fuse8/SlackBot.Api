using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Clients.Get.Request;
using SlackBot.Api.Clients.Get.Response;

namespace SlackBot.Api.Clients
{
	public class TeamProfileClient : SlackClientBase
	{
		public TeamProfileClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "team.profile";

		/// <summary>
		/// Retrieve a team's profile.
		/// </summary>
		public Task<TeamProfileResponse> GetAsync(TeamProfileRequest teamProfileRequest)
			=> SendGetAsync<TeamProfileRequest, TeamProfileResponse>("get", teamProfileRequest);
	}
}