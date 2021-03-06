﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public abstract class ClassicPaginationRequestBase
	{
		protected ClassicPaginationRequestBase()
		{
		}

		protected ClassicPaginationRequestBase(long? count, long? page)
		{
			Count = count;
			Page = page;
		}

		/// <summary>
		/// Number of items to return per page.
		/// <para><strong>Default: 100</strong></para>
		/// </summary>
		/// <example>20</example>
		[FormPropertyName("count")]
		public long? Count { get; set; }

		/// <summary>
		/// Page number of results to return.
		/// <para><strong>Default: 1</strong></para>
		/// </summary>
		/// <example>2</example>
		[FormPropertyName("page")]
		public long? Page { get; set; }
	}
}