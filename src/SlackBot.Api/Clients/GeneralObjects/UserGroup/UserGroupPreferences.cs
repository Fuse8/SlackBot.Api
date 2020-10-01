﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public class UserGroupPreferences
	{
		[JsonProperty("channels")]
		public List<string> ChannelIds { get; set; }
		
		[JsonProperty("groups")]
		public List<string> GroupIds { get; set; }
	}
}