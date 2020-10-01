using SlackBot.Api.Attributes;

namespace SlackBot.Api.Clients
{
	public class ChannelToCreate
	{
		public ChannelToCreate()
		{
		}

		public ChannelToCreate(string name, bool? isPrivate = null)
		{
			Name = name;
			IsPrivate = isPrivate;
		}

		/// <summary>
		/// Name of the public or private channel to create.
		/// Channel name may only contain lowercase letters, numbers, hyphens, and underscores, and must be 80 characters or less.
		/// </summary>
		/// <example>my-channel</example>
		[FormPropertyName("name")]
		public string Name { get; set; }

		/// <summary>
		/// Create a private channel instead of a public one
		/// <para><strong>Default: false</strong></para>
		/// </summary>
		/// <example>true</example>
		[FormPropertyName("is_private")]
		public bool? IsPrivate { get; set; }
	}
}