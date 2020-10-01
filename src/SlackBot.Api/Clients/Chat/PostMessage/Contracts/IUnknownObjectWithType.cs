using System.Collections.Generic;

namespace SlackBot.Api.Clients.PostMessage.Contracts
{
	public interface IUnknownObjectWithType
	{
		Dictionary<string, object> Properties { get; set; }
	}
}