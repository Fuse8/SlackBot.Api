using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class RemoteFileToShare : RemoteFileBaseRequest
	{
		public RemoteFileToShare()
		{
		}

		public RemoteFileToShare(string chanelIds, string fileId = null, string externalId = null)
			: base(fileId, externalId)
		{
			ChanelIds = chanelIds;
		}

		/// <summary>
		/// Comma-separated list of channel IDs where the file will be shared.
		/// </summary>
		/// <example>C1234567890,C2345678901,C3456789012</example>
		[FormPropertyName("channels")]
		public string ChanelIds { get; set; }
	}
}