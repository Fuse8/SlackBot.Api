namespace SlackBot.Api.Clients.Info.Request
{
	public class RemoteFileInfoRequest : RemoteFileBaseRequest
	{
		public RemoteFileInfoRequest()
		{
		}

		public RemoteFileInfoRequest(string fileId = null, string externalId= null)
			: base(fileId, externalId)
		{
		}
	}
}