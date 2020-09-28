namespace SlackBot.Api.Models.FileRemote.Info.Request
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