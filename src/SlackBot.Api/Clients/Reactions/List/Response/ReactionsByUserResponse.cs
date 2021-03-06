﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ReactionsByUserResponse : CursorPaginationResponseBase
	{
		[JsonProperty("items")]
		public List<ItemActionResponse> Items { get; set; }
	}
}