using SlackBot.Api.Attributes;
using SlackBot.Api.Models.GeneralObjects.Pagination;

namespace SlackBot.Api.Models.User.Conversation.Request
{
	public class UserConversations : CursorPaginationBase
	{
		[FormPropertyName("exclude_archived")]
		public bool? ExcludeArchived { get; set; }
	
		[FormPropertyName("limit")]
		public long? Limit { get; set; }
		
		[FormPropertyName("types")]
		public string Types { get; set; }
		
		[FormPropertyName("user")]
		public string User { get; set; }
	}
}