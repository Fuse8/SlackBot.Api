using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Enums;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.MessageObjects
{
	public class ConfirmationDialogObject
	{
		/// <summary>
		/// A <see cref="PlainTextObject"/> that defines the dialog's title.
		/// Maximum length for the <see cref="PlainTextObject.Text"/> in this field is 100 characters.
		/// </summary>
		[JsonProperty("title")]
		public PlainTextObject Title { get; set; }
		
		/// <summary>
		/// A <see cref="TextObjectBase"/> that defines the explanatory text that appears in the confirm dialog.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is 300 characters.
		/// </summary>
		[JsonProperty("text")]
		public TextObjectBase Text { get; set; }

		/// <summary>
		/// A <see cref="PlainTextObject"/> to define the text of the button that confirms the action.
		/// Maximum length for the <see cref="PlainTextObject.Text"/> in this field is 30 characters.
		/// </summary>
		[JsonProperty("confirm")]
		public PlainTextObject Confirm { get; set; }

		/// <summary>
		/// A <see cref="PlainTextObject"/> to define the text of the button that cancels the action.
		/// Maximum length for the <see cref="PlainTextObject.Text"/> in this field is 30 characters.
		/// </summary>
		[JsonProperty("deny")]
		public PlainTextObject Deny { get; set; }
		
		/// <summary>
		/// Defines the color scheme applied to the <see cref="Confirm"/> button.
		/// A value of <see cref="StyleType.Danger"/> will display the button with a red background on desktop, or red text on mobile.
		/// A value of <see cref="StyleType.Primary"/> will display the button with a green background on desktop, or blue text on mobile.
		/// <para><strong>Default: <see cref="StyleType.Primary"/></strong></para>
		/// </summary>
		[JsonProperty("style")]
		public StyleType? Style { get; set; }
	}
}