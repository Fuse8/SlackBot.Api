using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class UsersProfileClient : SlackClientBase
	{
		public UsersProfileClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "users.profile";

		/// <inheritdoc cref="GetAsync(UserProfileRequest)"/>
		public Task<UserProfileResponse> GetAsync(string userId = null, bool? includeLabels = null)
			=> GetAsync(new UserProfileRequest(userId, includeLabels));

		/// <summary>
		/// Retrieves a user's profile information.
		/// </summary>
		public Task<UserProfileResponse> GetAsync(UserProfileRequest userProfileRequest)
			=> SendGetAsync<UserProfileRequest, UserProfileResponse>("get", userProfileRequest);
	}
}