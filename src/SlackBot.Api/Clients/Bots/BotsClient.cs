using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class BotsClient : SlackClientBase
	{
		public BotsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "bots";
		
		/// <inheritdoc cref="BotsClient.InfoAsync(BotInfoRequest)"/>
		public Task<BotInfoResponse> InfoAsync(string botId)
			=> InfoAsync(new BotInfoRequest(botId));
		
		/// <summary>
		/// Gets information about a bot user.
		/// </summary>
		public Task<BotInfoResponse> InfoAsync(BotInfoRequest botInfoRequest)
			=> SendGetAsync<BotInfoRequest, BotInfoResponse>("info", botInfoRequest);
	}
}