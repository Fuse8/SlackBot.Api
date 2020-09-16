using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.BlockElements
{
	public class MultiSelectActionElement : ActionElementBase, ISectionElement, IInputElement
	{
		protected override string SectionType => "multi_static_select";

		[JsonProperty("options")]
		public OptionObject[] Options { get; set; }

		[JsonProperty("initial_options")]
		public OptionObject[] InitialOption { get; set; }

		[JsonProperty("placeholder")]
		public PlainTextObject Placeholder { get; set; }

		[JsonProperty("option_groups")]
		public OptionGroupObject OptionGroup { get; set; }

		[JsonProperty("max_selected_items")]
		public int? MaxSelectedItems { get; set; }
	}
}