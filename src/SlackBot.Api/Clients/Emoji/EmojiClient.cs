using System.Net.Http;
using System.Threading.Tasks;

namespace SlackBot.Api
{
	public class EmojiClient : SlackClientBase
	{
		public EmojiClient(HttpClient httpClient)
			: base(httpClient)
		{
		}

		protected override string ObjectPath => "emoji";
		
		/// <summary>
		/// Lists custom emoji for a team.
		/// </summary>
		public Task<EmojiListResponse> ListAsync()
			=> SendGetAsync<EmojiListResponse>("list");
	}
}