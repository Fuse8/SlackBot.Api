using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Clients.Add.Request;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Clients.Get.Request;
using SlackBot.Api.Clients.Get.Response;
using SlackBot.Api.Clients.List.Request;
using SlackBot.Api.Clients.List.Response;
using SlackBot.Api.Clients.Remove.Request;

namespace SlackBot.Api.Clients
{
	public class ReactionsClient : SlackClientBase
	{
		public ReactionsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "reactions";

		/// <summary>
		/// Adds a reaction to an item.
		/// </summary>
		public Task<SlackBaseResponse> AddAsync(Reaction reaction)
			=> SendPostFormUrlEncodedAsync("add", reaction);

		/// <summary>
		/// Gets reactions for an item.
		/// </summary>
		public Task<ReactionsByItemResponse> GetAsync(ReactionsByItemRequest reactionsByItemRequest)
			=> SendGetAsync<ReactionsByItemRequest, ReactionsByItemResponse>("get", reactionsByItemRequest);

		/// <summary>
		/// Lists reactions made by a user.
		/// </summary>
		public Task<ReactionsByUserResponse> ListAsync(ReactionsByUserRequest reactionsByUserRequest)
			=> SendGetAsync<ReactionsByUserRequest, ReactionsByUserResponse>("list", reactionsByUserRequest);

		/// <summary>
		/// Removes a reaction from an item.
		/// </summary>
		public Task<SlackBaseResponse> RemoveAsync(ReactionToRemove reactionToRemove)
			=> SendPostFormUrlEncodedAsync("remove", reactionToRemove);
	}
}