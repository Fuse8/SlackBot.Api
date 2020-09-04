using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Request.Sections;

namespace SlackBot.Api.Models.Chat.PostMessage.Request.BlockElements
{
	public class DatepickerActionElement : ActionElementBase
	{
		protected override string SectionType => "datepicker";

		[JsonProperty("action_id")]
		public string ActionId { get; set; }

		[JsonProperty("placeholder")]
		public PlainTextSection Placeholder { get; set; }

		[JsonProperty("initial_date")]
		public string InitialDate { get; set; }
		
		[JsonProperty("confirm")]
		public ConfirmSection Confirm { get; set; }
	}
}