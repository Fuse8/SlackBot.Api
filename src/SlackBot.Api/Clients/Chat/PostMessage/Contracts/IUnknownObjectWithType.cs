using System.Collections.Generic;

namespace SlackBot.Api
{
	public interface IUnknownObjectWithType
	{
		Dictionary<string, object> Properties { get; set; }
	}
}