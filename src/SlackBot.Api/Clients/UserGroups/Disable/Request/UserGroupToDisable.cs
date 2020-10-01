namespace SlackBot.Api.Clients.Disable.Request
{
	public class UserGroupToDisable : UserGroupActionRequestBase
	{
		public UserGroupToDisable()
		{
		}

		public UserGroupToDisable(string userGroupId, bool? includeUserCount = null)
			: base(userGroupId, includeUserCount)
		{
		}
	}
}