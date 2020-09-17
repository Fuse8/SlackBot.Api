﻿using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.Models.Chat.PostMessage.BlockElements
{
	public class MultiSelectActionElement : ActionElementBase, ISectionElement, IInputElement
	{
		protected override string SectionType => "multi_static_select";

		/// <summary>
		/// A <see cref="PlainTextObject"/> only text object that defines the placeholder text shown on the menu.
		/// Maximum length for the <see cref="TextObjectBase.Text"/> in this field is 150 characters.
		/// </summary>
		[JsonProperty("placeholder")]
		public PlainTextObject Placeholder { get; set; }
		
		/// <summary>
		/// An array of <see cref="OptionObject"/>. Maximum number of options is 100. If <see cref="OptionGroups"/> is specified, this field should not be.
		/// </summary>
		[JsonProperty("options")]
		public OptionObject[] Options { get; set; }

		/// <summary>
		/// An array of <see cref="OptionGroupObject"/>. Maximum number of option groups is 100. If <see cref="Options"/> is specified, this field should not be.
		/// </summary>
		[JsonProperty("option_groups")]
		public OptionGroupObject[] OptionGroups { get; set; }

		/// <summary>
		/// An array of <see cref="OptionObject"/> that exactly match one or more of the options within <see cref="Options"/> or <see cref="OptionGroups"/>.
		/// These options will be selected when the menu initially loads.
		/// </summary>
		[JsonProperty("initial_options")]
		public OptionObject[] InitialOptions { get; set; }

		/// <summary>
		/// Specifies the maximum number of items that can be selected in the menu. Minimum number is 1.
		/// </summary>
		[JsonProperty("max_selected_items")]
		public long? MaxSelectedItems { get; set; }
	}
}