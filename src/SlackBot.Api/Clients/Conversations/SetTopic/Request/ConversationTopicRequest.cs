using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients.SetTopic.Request
{
	public class ConversationTopicRequest : ConversationRequestBase
	{
		public ConversationTopicRequest()
		{
		}

		public ConversationTopicRequest(string channelId, string topic)
			: base(channelId)
		{
			Topic = topic;
		}

		/// <summary>
		/// The new topic string. Does not support formatting or linkification.
		/// </summary>
		/// <example>Apply topically for best effects</example>
		[FormPropertyName("topic")]
		public string Topic { get; set; }
	}
}