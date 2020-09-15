using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.BlockElements
{
	public class DatepickerActionElement : ActionElementBase, ISectionElement, IActionElement, IInputElement
	{
		protected override string SectionType => "datepicker";

		[JsonProperty("placeholder")]
		public PlainTextObject Placeholder { get; set; }

		[JsonProperty("initial_date")]
		public string InitialDate { get; set; }
	}
}