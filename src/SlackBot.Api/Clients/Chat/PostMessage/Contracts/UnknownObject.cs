using System.Collections.Generic;

namespace SlackBot.Api.Clients
{
	/// <summary>
	///     Do not use in request to the slack.
	///     This type is only used to parse unknown models in Slack responses
	/// </summary>
	public class UnknownObject : BlockBase, IUnknownObjectWithType, IActionElement, IContextElement, IInputElement, ISectionElement
	{
		protected override string SectionType => null;

		public Dictionary<string, object> Properties { get; set; }
	}
}