using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements
{
	public class CheckboxActionElement : ActionElementBase
	{
		protected override string SectionType => "checkboxes";

		[JsonProperty("action_id")]
		public string ActionId { get; set; }

		[JsonProperty("options")]
		public OptionSection[] Options { get; set; }

		[JsonProperty("initial_options")]
		public OptionSection[] InitialOption { get; set; }
		
		[JsonProperty("confirm")]
		public ConfirmSection Confirm { get; set; }
	}
}