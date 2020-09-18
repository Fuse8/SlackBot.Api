﻿using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.Chat.ScheduledMessagesList.Response
{
	public class ScheduledMessagesResponse : CursorPaginationResponseBase
	{
		[JsonProperty("scheduled_messages")]
		public ScheduledMessage[] ScheduledMessages { get; set; }
	}
}