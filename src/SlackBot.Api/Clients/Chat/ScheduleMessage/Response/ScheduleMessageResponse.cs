﻿using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class ScheduleMessageResponse : PostMessageResponseBase
	{
		[JsonProperty("scheduled_message_id")]
		public string ScheduledMessageId { get; set; }

		[JsonProperty("post_at")]
		public string PostAtTimestamp { get; set; }
	}
}