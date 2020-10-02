using System.Threading.Tasks;
using SlackBot.Api;

namespace SlackBot.Samples.ClientExtensions
{
	internal static class EmojiClientMethods
	{
		public static Task<EmojiListResponse> GetEmojiListAsync(EmojiClient emojiClient)
			=> emojiClient.ListAsync();
	}
}