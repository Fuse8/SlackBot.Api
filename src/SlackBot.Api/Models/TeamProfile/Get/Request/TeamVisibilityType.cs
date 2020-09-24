using SlackBot.Api.Models.TeamProfile.Get.Response;

namespace SlackBot.Api.Models.TeamProfile.Get.Request
{
	public enum TeamFieldVisibilityType
	{
		/// <summary>
		/// All fields
		/// </summary>
		All,
		
		/// <summary>
		///  Only fields for which the <see cref="TeamField.IsHidden"/> option is missing or "false".
		/// </summary>
		Visible,
		
		/// <summary>
		/// Only fields for which the <see cref="TeamField.IsHidden"/> option is "true".
		/// </summary>
		Hidden
	}
}