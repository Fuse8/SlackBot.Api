using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models.UserProfile.Get.Request;
using SlackBot.Api.Models.UserProfile.Get.Response;

namespace SlackBot.Api.Clients
{
	public class UsersProfileClient : SlackClientBase
	{
		public UsersProfileClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "users.profile";

		/// <summary>
		/// Retrieves a user's profile information.
		/// </summary>
		public Task<UserProfileResponse> GetAsync(UserProfileRequest userProfileRequest)
			=> SendGetAsync<UserProfileRequest, UserProfileResponse>("get", userProfileRequest);
	}
}