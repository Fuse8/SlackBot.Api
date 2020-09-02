﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.UserConversationModels
{
	public class UserConversations
	{
		[FormPropertyName("cursor")]
		public string Cursor { get; set; }

		[FormPropertyName("exclude_archived")]
		public bool ExcludeArchived { get; set; }
	
		[FormPropertyName("limit")]
		public int? Limit { get; set; }
		
		[FormPropertyName("types")]
		public string Types { get; set; }
		
		[FormPropertyName("user")]
		public string User { get; set; }
	}
}