using System.Collections.Generic;

namespace SlackBot.Api.Clients
{
	public interface IUnknownObjectWithType
	{
		Dictionary<string, object> Properties { get; set; }
	}
}