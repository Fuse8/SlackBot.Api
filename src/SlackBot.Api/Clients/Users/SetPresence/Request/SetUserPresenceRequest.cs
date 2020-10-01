using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class SetUserPresenceRequest
	{
		public SetUserPresenceRequest()
		{
		}

		public SetUserPresenceRequest(string presence)
		{
			Presence = presence;
		}

		/// <summary>
		/// Either "auto" or "away"
		/// </summary>
		/// <example>away</example>
		[FormPropertyName("presence")]
		public string Presence { get; set; }
	}
}