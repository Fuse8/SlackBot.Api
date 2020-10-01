namespace SlackBot.Api.Clients.GetPresence.Request
{
	public class UserPresenceRequest
	{
		public UserPresenceRequest()
		{
		}

		public UserPresenceRequest(string userId)
		{
			UserId = userId;
		}

		/// <summary>
		/// User to get presence info on.
		/// <para><strong>Default: authed user</strong></para>
		/// </summary>
		/// <example>W1234567890</example>
		public string UserId { get; set; }
	}
}