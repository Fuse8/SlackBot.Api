using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.UserModels.ConversationModels.ResponseModels
{
	public class Channel
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("is_channel")]
		public bool IsChannel { get; set; }

		[JsonPropertyName("is_group")]
		public bool IsGroup { get; set; }

		[JsonPropertyName("is_im")]
		public bool IsDirectMessageChannel { get; set; }

		[JsonPropertyName("created")]
		public long Created { get; set; }

		[JsonPropertyName("creator")]
		public string Creator { get; set; }

		[JsonPropertyName("is_archived")]
		public bool IsArchived { get; set; }

		[JsonPropertyName("is_general")]
		public bool IsGeneral { get; set; }

		[JsonPropertyName("unlinked")]
		public long Unlinked { get; set; }

		[JsonPropertyName("name_normalized")]
		public string NameNormalized { get; set; }

		[JsonPropertyName("is_read_only")]
		public bool IsReadOnly { get; set; }

		[JsonPropertyName("is_shared")]
		public bool IsShared { get; set; }

		[JsonPropertyName("is_ext_shared")]
		public bool IsExtShared { get; set; }

		[JsonPropertyName("is_org_shared")]
		public bool IsOrgShared { get; set; }

		[JsonPropertyName("pending_shared")]
		public object[] PendingShared { get; set; }

		[JsonPropertyName("is_pending_ext_shared")]
		public bool IsPendingExtShared { get; set; }

		[JsonPropertyName("is_member")]
		public bool IsMember { get; set; }

		[JsonPropertyName("is_private")]
		public bool IsPrivate { get; set; }

		[JsonPropertyName("is_mpim")]
		public bool IsMpim { get; set; }

		[JsonPropertyName("last_read")]
		public string LastRead { get; set; }

		[JsonPropertyName("topic")]
		public Purpose Topic { get; set; }

		[JsonPropertyName("purpose")]
		public Purpose Purpose { get; set; }

		[JsonPropertyName("previous_names")]
		public string[] PreviousNames { get; set; }

		[JsonPropertyName("num_members")]
		public long NumMembers { get; set; }

		[JsonPropertyName("locale")]
		public string Locale { get; set; }
	}
}