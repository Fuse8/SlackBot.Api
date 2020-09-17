using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.BlockElements
{
	public class DatepickerActionElement : ActionElementBase, ISectionElement, IActionElement, IInputElement
	{
		protected override string SectionType => "datepicker";

		/// <summary>
		/// A <see cref="PlainTextObject"/> only text object that defines the placeholder text shown on the datepicker.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is 150 characters.
		/// </summary>
		[JsonProperty("placeholder")]
		public PlainTextObject Placeholder { get; set; }

		/// <summary>
		/// The initial date that is selected when the element is loaded. This should be in the format "YYYY-MM-DD".
		/// </summary>
		[JsonProperty("initial_date")]
		public string InitialDate { get; set; }
	}
}