using System.Collections.Generic;

namespace SlackBot.Api.Models.Chat.PostMessage.Contracts
{
	public interface IUnknownObjectWithType
	{
		Dictionary<string, object> Properties { get; set; }
	}
}