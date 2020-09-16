using Newtonsoft.Json;

namespace SlackBot.Api.Models.User.Conversation.Response
{
	public class Channel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("is_channel")]
		public bool? IsChannel { get; set; }

		[JsonProperty("is_group")]
		public bool? IsGroup { get; set; }

		[JsonProperty("is_im")]
		public bool? IsDirectMessageChannel { get; set; }

		[JsonProperty("is_mpim")]
		public bool? IsMultiPersonDirectMessageChannel { get; set; }

		[JsonProperty("created")]
		public long? Created { get; set; }

		[JsonProperty("creator")]
		public string Creator { get; set; }

		[JsonProperty("is_archived")]
		public bool? IsArchived { get; set; }

		[JsonProperty("is_general")]
		public bool? IsGeneral { get; set; }

		[JsonProperty("unlinked")]
		public long? Unlinked { get; set; }

		[JsonProperty("name_normalized")]
		public string NameNormalized { get; set; }

		[JsonProperty("is_read_only")]
		public bool? IsReadOnly { get; set; }

		[JsonProperty("is_shared")]
		public bool? IsShared { get; set; }

		[JsonProperty("is_ext_shared")]
		public bool? IsExtShared { get; set; }

		[JsonProperty("is_org_shared")]
		public bool? IsOrgShared { get; set; }

		[JsonProperty("pending_shared")]
		public object[] PendingShared { get; set; } // TODO Couldn't find a description of this field in the documentation

		[JsonProperty("is_pending_ext_shared")]
		public bool? IsPendingExtShared { get; set; }

		[JsonProperty("is_member")]
		public bool? IsMember { get; set; }

		[JsonProperty("is_private")]
		public bool? IsPrivate { get; set; }

		[JsonProperty("last_read")]
		public string LastRead { get; set; }

		[JsonProperty("topic")]
		public Purpose Topic { get; set; }

		[JsonProperty("purpose")]
		public Purpose Purpose { get; set; }

		[JsonProperty("previous_names")]
		public string[] PreviousNames { get; set; }

		[JsonProperty("num_members")]
		public long? NumMembers { get; set; }

		[JsonProperty("locale")]
		public string Locale { get; set; }
	}
}