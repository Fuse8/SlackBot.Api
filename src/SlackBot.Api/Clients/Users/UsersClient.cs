using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class UsersClient : SlackClientBase
	{
		public UsersClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "users";

		/// <summary>
		/// Gets conversations list the calling user may access.
		/// </summary>
		public Task<ConversationObjectListResponse> ConversationsAsync(UserConversations userConversations)
			=> SendGetAsync<UserConversations, ConversationObjectListResponse>("conversations", userConversations);

		/// <summary>
		/// Gets user presence information.
		/// </summary>
		public Task<UserPresenceResponse> GetPresenceAsync(UserPresenceRequest userPresenceRequest)
			=> SendGetAsync<UserPresenceRequest, UserPresenceResponse>("getPresence", userPresenceRequest);

		/// <summary>
		/// Gets information about a user.
		/// </summary>
		public Task<UserResponse> InfoAsync(UserToGetInfo userToGetInfo)
			=> SendGetAsync<UserToGetInfo, UserResponse>("info", userToGetInfo);

		/// <summary>
		/// Lists all users in a Slack team.
		/// </summary>
		public Task<UserListResponse> ListAsync(UserListRequest userListRequest)
			=> SendGetAsync<UserListRequest, UserListResponse>("list", userListRequest);

		/// <summary>
		/// Find a user with an email address.
		/// </summary>
		public Task<UserResponse> LookupByEmailAsync(UserByEmailRequest userByEmailRequest)
			=> SendGetAsync<UserByEmailRequest, UserResponse>("lookupByEmail", userByEmailRequest);

		/// <summary>
		/// Manually sets user presence.
		/// </summary>
		public Task<SlackBaseResponse> SetPresenceAsync(SetUserPresenceRequest setUserPresenceRequest)
			=> SendPostFormUrlEncodedAsync("setPresence", setUserPresenceRequest);
	}
}