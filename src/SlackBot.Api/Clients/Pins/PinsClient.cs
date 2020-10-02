using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class PinsClient : SlackClientBase
	{
		public PinsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "pins";

		/// <inheritdoc cref="PinAsync(PinItem)"/>
		public Task<SlackBaseResponse> PinAsync(string channelId, string messageTimestamp)
			=> PinAsync(new PinItem(channelId, messageTimestamp));

		/// <summary>
		/// Pins an item to a channel.
		/// </summary>
		public Task<SlackBaseResponse> PinAsync(PinItem pinItem)
			=> SendPostFormUrlEncodedAsync("add", pinItem);

		/// <inheritdoc cref="ListAsync(PinListRequest)"/>
		public Task<PinListResponse> ListAsync(string channelId)
			=> ListAsync(new PinListRequest(channelId));

		/// <summary>
		/// Lists items pinned to a channel.
		/// </summary>
		public Task<PinListResponse> ListAsync(PinListRequest pinListRequest)
			=> SendGetAsync<PinListRequest, PinListResponse>("list", pinListRequest);

		/// <inheritdoc cref="RemoveAsync(PinItemToRemove)"/>
		public Task<SlackBaseResponse> RemoveAsync(string channelId, string messageTimestamp)
			=> RemoveAsync(new PinItemToRemove(channelId, messageTimestamp));

		/// <summary>
		/// Un-pins an item from a channel.
		/// </summary>
		public Task<SlackBaseResponse> RemoveAsync(PinItemToRemove pinItemToRemove)
			=> SendPostFormUrlEncodedAsync("remove", pinItemToRemove);
	}
}