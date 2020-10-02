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

		/// <summary>
		/// Pins an item to a channel.
		/// </summary>
		public Task<SlackBaseResponse> PinAsync(PinItem pinItem)
			=> SendPostFormUrlEncodedAsync("add", pinItem);

		/// <summary>
		/// Lists items pinned to a channel.
		/// </summary>
		public Task<PinListResponse> ListAsync(PinListRequest pinListRequest)
			=> SendGetAsync<PinListRequest, PinListResponse>("list", pinListRequest);

		/// <summary>
		/// Un-pins an item from a channel.
		/// </summary>
		public Task<SlackBaseResponse> RemoveAsync(PinItemToRemove pinItemToRemove)
			=> SendPostFormUrlEncodedAsync("remove", pinItemToRemove);
	}
}