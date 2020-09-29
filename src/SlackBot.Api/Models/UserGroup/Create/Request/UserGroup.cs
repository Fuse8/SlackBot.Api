using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.UserGroup.Create.Request
{
	public class UserGroup
	{
		public UserGroup()
		{
		}

		public UserGroup(string name, string handle = null, string channelIds = null, string description = null)
		{
			Name = name;
			Handle = handle;
			ChannelIds = channelIds;
			Description = description;
		}

		/// <summary>
		/// A name for the User Group. Must be unique among User Groups.
		/// </summary>
		/// <example>My Test Team</example>
		[FormPropertyName("name")]
		public string Name { get; set; }

		/// <summary>
		/// A comma separated string of encoded channel IDs for which the User Group uses as a default.
		/// </summary>
		/// <example>C1234567890,C2345678901,C3456789012</example>
		[FormPropertyName("channels")]
		public string ChannelIds { get; set; }

		/// <summary>
		/// A short description of the User Group.
		/// </summary>
		/// <example>Short description</example>
		[FormPropertyName("description")]
		public string Description { get; set; }

		/// <summary>
		/// A mention handle. Must be unique among channels, users and User Groups.
		/// </summary>
		/// <example>marketing</example>
		[FormPropertyName("handle")]
		public string Handle { get; set; }

		/// <summary>
		/// Include the number of users in each User Group.
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("include_count")]
		public bool? IncludeUserCount { get; set; }
	}
}