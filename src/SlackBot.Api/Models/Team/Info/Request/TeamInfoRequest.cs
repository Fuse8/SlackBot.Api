using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.Team.Info.Request
{
	public class TeamInfoRequest
	{
		public TeamInfoRequest()
		{
		}

		public TeamInfoRequest(string teamId)
		{
			TeamId = teamId;
		}

		/// <summary>
		/// Team to get info on. Will only return team that the authenticated token is allowed to see through external shared channels.
		/// <para><strong>Default: current team</strong></para>
		/// </summary>
		[FormPropertyName("team")]
		public string TeamId { get; set; }
	}
}