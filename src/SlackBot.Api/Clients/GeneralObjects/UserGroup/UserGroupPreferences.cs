using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class UserGroupPreferences
	{
		[JsonProperty("channels")]
		public List<string> ChannelIds { get; set; }
		
		[JsonProperty("groups")]
		public List<string> GroupIds { get; set; }
	}
}