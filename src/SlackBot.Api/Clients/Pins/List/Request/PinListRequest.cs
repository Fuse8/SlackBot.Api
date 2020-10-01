using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class PinListRequest
	{
		public PinListRequest()
		{
		}

		public PinListRequest(string channelId)
		{
			ChannelId = channelId;
		}

		/// <summary>
		/// Channel to get pinned items for.
		/// </summary>
		/// <example>C1234567890</example>
		[FormPropertyName("channel")]
		public string ChannelId { get; set; }
	}
}