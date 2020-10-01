using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public abstract class RemoteFileBaseRequest
	{
		protected RemoteFileBaseRequest()
		{
		}

		protected RemoteFileBaseRequest(string fileId, string externalId)
		{
			FileId = fileId;
			ExternalId = externalId;
		}

		/// <summary>
		/// Creator defined GUID for the file.
		/// </summary>
		/// <example>123456</example>
		[FormPropertyName("external_id")]
		public string ExternalId { get; set; }

		/// <summary>
		/// Specify a file by providing its ID.
		/// </summary>
		/// <example>F2147483862</example>
		[FormPropertyName("file")]
		public string FileId { get; set; }
	}
}