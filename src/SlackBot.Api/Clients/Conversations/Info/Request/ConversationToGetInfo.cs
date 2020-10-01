using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class ConversationToGetInfo : ConversationRequestBase
	{
		public ConversationToGetInfo()
		{
		}

		public ConversationToGetInfo(string channelId, bool? includeLocale = null, bool? includeMemberCount = null)
			: base(channelId)
		{
			IncludeLocale = includeLocale;
			IncludeMemberCount = includeMemberCount;
		}

		/// <summary>
		/// Set this to "true" to receive the locale for this conversation.
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_locale")]
		public bool? IncludeLocale { get; set; }

		/// <summary>
		/// Set to "true" to include the member count for the specified conversation
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_num_members")]
		public bool? IncludeMemberCount { get; set; }
	}
}