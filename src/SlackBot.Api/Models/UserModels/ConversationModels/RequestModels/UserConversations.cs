using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.UserModels.ConversationModels.RequestModels
{
	public class UserConversations
	{
		[FormPropertyName("cursor")]
		public string Cursor { get; set; }

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