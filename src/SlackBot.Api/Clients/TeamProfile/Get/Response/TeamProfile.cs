using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class TeamProfile
	{
		[JsonProperty("fields")]
		public List<TeamField> Fields { get; set; }
	}
}