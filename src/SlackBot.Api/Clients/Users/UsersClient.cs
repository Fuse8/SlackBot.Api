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

		/// <inheritdoc cref="ConversationsAsync(UserConversations)"/>
		public Task<ConversationObjectListResponse> ConversationsAsync(string types = null, string userId = null)
			=> ConversationsAsync(new UserConversations(types, userId));

		/// <summary>
		/// Gets conversations list the calling user may access.
		/// </summary>
		public Task<ConversationObjectListResponse> ConversationsAsync(UserConversations userConversations)
			=> SendGetAsync<UserConversations, ConversationObjectListResponse>("conversations", userConversations);

		/// <inheritdoc cref="GetPresenceAsync(UserPresenceRequest)"/>
		public Task<UserPresenceResponse> GetPresenceAsync(string userId = null)
			=> GetPresenceAsync(new UserPresenceRequest(userId));

		/// <summary>
		/// Gets user presence information.
		/// </summary>
		public Task<UserPresenceResponse> GetPresenceAsync(UserPresenceRequest userPresenceRequest)
			=> SendGetAsync<UserPresenceRequest, UserPresenceResponse>("getPresence", userPresenceRequest);

		/// <inheritdoc cref="InfoAsync(UserToGetInfo)"/>
		public Task<UserResponse> InfoAsync(string userId)
			=> InfoAsync(new UserToGetInfo(userId));

		/// <summary>
		/// Gets information about a user.
		/// </summary>
		public Task<UserResponse> InfoAsync(UserToGetInfo userToGetInfo)
			=> SendGetAsync<UserToGetInfo, UserResponse>("info", userToGetInfo);

		/// <inheritdoc cref="ListAsync(UserListRequest)"/>
		public Task<UserListResponse> ListAsync(string cursor = null, long? limit = null, bool? includeLocale = null)
			=> ListAsync(new UserListRequest(cursor, limit, includeLocale));

		/// <summary>
		/// Lists all users in a Slack team.
		/// </summary>
		public Task<UserListResponse> ListAsync(UserListRequest userListRequest)
			=> SendGetAsync<UserListRequest, UserListResponse>("list", userListRequest);

		/// <inheritdoc cref="LookupByEmailAsync(UserByEmailRequest)"/>
		public Task<UserResponse> LookupByEmailAsync(string email)
			=> LookupByEmailAsync(new UserByEmailRequest(email));

		/// <summary>
		/// Find a user with an email address.
		/// </summary>
		public Task<UserResponse> LookupByEmailAsync(UserByEmailRequest userByEmailRequest)
			=> SendGetAsync<UserByEmailRequest, UserResponse>("lookupByEmail", userByEmailRequest);

		/// <inheritdoc cref="SetPresenceAsync(SetUserPresenceRequest)"/>
		public Task<SlackBaseResponse> SetPresenceAsync(string presence)
			=> SetPresenceAsync(new SetUserPresenceRequest(presence));

		/// <summary>
		/// Manually sets user presence.
		/// </summary>
		public Task<SlackBaseResponse> SetPresenceAsync(SetUserPresenceRequest setUserPresenceRequest)
			=> SendPostFormUrlEncodedAsync("setPresence", setUserPresenceRequest);
	}
}