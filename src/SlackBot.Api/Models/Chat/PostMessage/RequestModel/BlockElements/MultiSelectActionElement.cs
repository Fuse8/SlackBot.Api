using Newtonsoft.Json;
using SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.Sections;

namespace SlackBot.Api.Models.ChatModels.PostMessageModels.RequestModel.BlockElements
{
	public class MultiSelectActionElement : CheckboxActionElement
	{
		protected override string SectionType => "multi_static_select";

		[JsonProperty("placeholder")]
		public PlainTextSection Placeholder { get; set; }

		[JsonProperty("option_groups")]
		public OptionGroupSection OptionGroup { get; set; }

		[JsonProperty("max_selected_items")]
		public int? MaxSelectedItems { get; set; }
	}
}