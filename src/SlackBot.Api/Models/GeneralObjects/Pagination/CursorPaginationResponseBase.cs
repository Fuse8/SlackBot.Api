﻿using Newtonsoft.Json;

namespace SlackBot.Api.Models.GeneralObjects.Pagination
{
	public abstract class CursorPaginationResponseBase : SlackBaseResponse
	{
		[JsonProperty("response_metadata")]
		public CursorPaginationMetadata Metadata { get; set; }
	}
}