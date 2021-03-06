﻿using SlackBot.Api.Attributes;

namespace SlackBot.Api
{
	public class UserGroupToUpdate : SlackUserGroup
	{
		public UserGroupToUpdate()
		{
		}

		public UserGroupToUpdate(string userGroupId, string name = null, string description = null, string channelIds = null, string handle = null)
			: base(name, handle, channelIds, description)
		{
			UserGroupId = userGroupId;
		}

		/// <summary>
		/// The encoded ID of the User Group to update.
		/// </summary>
		/// <example>S06045678</example>
		[FormPropertyName("usergroup")]
		public string UserGroupId { get; set; }
	}
}