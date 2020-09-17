using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements
{
	public abstract class ActionElementBase : ObjectWithType
	{
		/// <summary>
		/// An identifier for this action. You can use this when you receive an "interaction payload" to identify the source of the action.
		/// Should be unique among all other <see cref="ActionId"/> used elsewhere by your app. Maximum length for this field is 255 characters.
		/// </summary>
		[JsonProperty("action_id")] //TODO mark Maximum length as bold
		public string ActionId { get; set; }

		/// <summary>
		/// A <see cref="ConfirmationDialogObject"/> that defines an optional confirmation dialog after the button is clicked.
		/// </summary>
		[JsonProperty("confirm")]
		public ConfirmationDialogObject Confirm { get; set; }
	}
}