using SlackBot.Api.Attributes;
using SlackBot.Api.Models.GeneralObjects.Pagination.Cursor;

namespace SlackBot.Api.Models.Reaction.List.Request
{
	public class ReactionsByUserRequest : CursorPaginationBase
	{
		public ReactionsByUserRequest()
		{
		}

		public ReactionsByUserRequest(string cursor, long? limit = null, string userId = null)
			: base(cursor, limit)
		{
			UserId = userId;
		}

		/// <summary>
		/// Number of items to return per page.
		/// <para><strong>Default: 100</strong></para>
		/// </summary>
		/// <example>20</example>
		[FormPropertyName("count")]
		public long? Count { get; set; }

		/// <summary>
		/// If "true" always return the complete reaction list.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("full")]
		public bool? Full { get; set; }

		/// <summary>
		/// Page number of results to return.
		/// <para><strong>Default: 1</strong></para>
		/// </summary>
		/// <example>2</example>
		[FormPropertyName("page")]
		public long? Page { get; set; }

		/// <summary>
		/// Show reactions made by this user.
		/// <para><strong>Default: authed user</strong></para>
		/// </summary>
		/// <example>W1234567890</example>
		[FormPropertyName("user")]
		public string UserId { get; set; }
	}
}