using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Api
{
	public class MessageToSchedule : SlackMessage
	{
		public MessageToSchedule()
		{
		}

		public MessageToSchedule(string channelIdOrName, long postAt, string text = null, List<Attachment> attachments = null, List<BlockBase> blocks = null)
			: base(channelIdOrName, text, attachments, blocks)
		{
			PostAt = postAt;
		}

		/// <summary>
		/// Unix EPOCH timestamp of time in future to send the message.
		/// </summary>
		/// <example>299876400</example>
		[JsonProperty("post_at")]
		public long PostAt { get; set; }
	}
}