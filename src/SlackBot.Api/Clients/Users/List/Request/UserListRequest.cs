﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class UserListRequest : CursorPaginationRequestBase
	{
		public UserListRequest()
		{
		}

		public UserListRequest(string cursor, long? limit = null)
			: base(cursor, limit)
		{
		}

		/// <summary>
		/// Set this to "true" to receive the locale for users.
		/// <para><strong>Default: false</strong></para> 
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_locale")]
		public bool? IncludeLocale { get; set; }
	}
}