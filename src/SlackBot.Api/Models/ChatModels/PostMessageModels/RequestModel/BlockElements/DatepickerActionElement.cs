using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements
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