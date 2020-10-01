namespace SlackBot.Api.Clients
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