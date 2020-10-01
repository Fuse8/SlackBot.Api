using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public abstract class ActionElementBase : ObjectWithType
	{
		/// <summary>
		/// An identifier for this action. You can use this when you receive an "interaction payload" to identify the source of the action.
		/// Should be unique among all other <see cref="ActionId"/> used elsewhere by your app. Maximum length for this field is <strong>255 characters</strong>.
		/// </summary>
		[JsonProperty("action_id")]
		public string ActionId { get; set; }

		/// <summary>
		/// A <see cref="ConfirmationDialogObject"/> that defines an optional confirmation dialog after the button is clicked.
		/// </summary>
		[JsonProperty("confirm")]
		public ConfirmationDialogObject Confirm { get; set; }
	}
}