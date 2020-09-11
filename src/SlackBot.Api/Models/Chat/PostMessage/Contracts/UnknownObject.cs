using System.Collections.Generic;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts
{
	/// <summary>
	/// Do not use in request to the slack.
	/// This type is only used to parse unknown models in Slack responses   
	/// </summary>
	public class UnknownObject : BlockBase, IUnknownObjectWithType, IActionElement, IContextElement, IInputElement, ISectionElement
	{
		protected override string SectionType => null;
		
		public Dictionary<string, object> Properties { get; set; }
	}
}