using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.Request.MessageObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.BlockElements
{
	public class DatepickerActionElement : ActionElementBase, ISectionElement, IActionElement, IInputElement
	{
		protected override string SectionType => "datepicker";

		[JsonProperty("placeholder")]
		public PlainTextObject Placeholder { get; set; }

		[JsonProperty("initial_date")]
		public string InitialDate { get; set; }
		
		[JsonProperty("confirm")]
		public ConfirmObject Confirm { get; set; }
	}
}