namespace SlackBot.Api.Models.UserGroup.Enable.Request
{
	public class UserGroupToEnable : UserGroupActionRequestBase
	{
		public UserGroupToEnable()
		{
		}

		public UserGroupToEnable(string userGroupId, bool? includeUserCount = null)
			: base(userGroupId, includeUserCount)
		{
		}
	}
}