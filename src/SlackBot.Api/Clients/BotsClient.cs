using System.Net.Http;
using System.Threading.Tasks;
using SlackBot.Api.Models.Bot.Info.Request;
using SlackBot.Api.Models.Bot.Info.Response;

namespace SlackBot.Api.Clients
{
	public class BotsClient : SlackClientBase
	{
		public BotsClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "bots";
		
		/// <summary>
		/// Gets information about a bot user.
		/// </summary>
		public Task<BotInfoResponse> InfoAsync(BotInfoRequest botInfoRequest)
			=> SendGetAsync<BotInfoRequest, BotInfoResponse>("info", botInfoRequest);
	}
}