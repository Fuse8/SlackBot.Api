﻿using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public abstract class CursorPaginationResponseBase : SlackBaseResponse
	{
		[JsonProperty("response_metadata")]
		public CursorPaginationMetadata Metadata { get; set; }
	}
}