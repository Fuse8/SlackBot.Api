using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class ReactionsClient : SlackClientBase
	{
		public ReactionsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "reactions";

		/// <inheritdoc cref="AddAsync(SlackReaction)"/>
		public Task<SlackBaseResponse> AddAsync(string channelId, string messageTimestamp, string emojiName)
			=> AddAsync(new SlackReaction(channelId, messageTimestamp, emojiName));

		/// <summary>
		/// Adds a reaction to an item.
		/// </summary>
		public Task<SlackBaseResponse> AddAsync(SlackReaction slackReaction)
			=> SendPostFormUrlEncodedAsync("add", slackReaction);

		/// <inheritdoc cref="GetAsync(ReactionsByItemRequest)"/>
		public Task<ReactionsByItemResponse> GetAsync(string channelId, string messageTimestamp)
			=> GetAsync(new ReactionsByItemRequest(channelId, messageTimestamp));

		/// <summary>
		/// Gets reactions for an item.
		/// </summary>
		public Task<ReactionsByItemResponse> GetAsync(ReactionsByItemRequest reactionsByItemRequest)
			=> SendGetAsync<ReactionsByItemRequest, ReactionsByItemResponse>("get", reactionsByItemRequest);

		/// <inheritdoc cref="ListAsync(ReactionsByUserRequest)"/>
		public Task<ReactionsByUserResponse> ListAsync(string userId = null, string cursor = null, long? limit = null)
			=> ListAsync(new ReactionsByUserRequest(userId, cursor, limit));

		/// <summary>
		/// Lists reactions made by a user.
		/// </summary>
		public Task<ReactionsByUserResponse> ListAsync(ReactionsByUserRequest reactionsByUserRequest)
			=> SendGetAsync<ReactionsByUserRequest, ReactionsByUserResponse>("list", reactionsByUserRequest);

		/// <inheritdoc cref="RemoveAsync(ReactionToRemove)"/>
		public Task<SlackBaseResponse> RemoveAsync(string channelId, string messageTimestamp, string emojiName)
			=> RemoveAsync(new ReactionToRemove(channelId, messageTimestamp, emojiName));

		/// <summary>
		/// Removes a reaction from an item.
		/// </summary>
		public Task<SlackBaseResponse> RemoveAsync(ReactionToRemove reactionToRemove)
			=> SendPostFormUrlEncodedAsync("remove", reactionToRemove);
	}
}