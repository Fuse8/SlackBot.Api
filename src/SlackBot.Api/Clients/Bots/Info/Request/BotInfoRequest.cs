﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class BotInfoRequest
	{
		public BotInfoRequest()
		{
		}

		public BotInfoRequest(string botId)
		{
			BotId = botId;
		}

		/// <summary>
		/// Bot user to get info on
		/// </summary>
		/// <example>B12345678</example>
		[FormPropertyName("bot")]
		public string BotId { get; set; }
	}
}