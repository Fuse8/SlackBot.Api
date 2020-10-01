using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class UserByEmailRequest
	{
		public UserByEmailRequest()
		{
		}

		public UserByEmailRequest(string email)
		{
			Email = email;
		}

		/// <summary>
		/// An email address belonging to a user in the workspace.
		/// </summary>
		/// <example>spengler@ghostbusters.example.com</example>
		[FormPropertyName("email")]
		public string Email { get; set; }
	}
}