using Newtonsoft.Json;

namespace SlackBot.Api
{
	public abstract class BlockBase : ObjectWithType
	{
		/// <summary>
		/// A string acting as a unique identifier for a block. If not specified, a <see cref="BlockId"/> will be generated.
		/// You can use this <see cref="BlockId"/> when you receive an interaction payload to identify the source of the action.
		/// Maximum length for this field is <strong>255 characters</strong>.
		/// <see cref="BlockId"/> should be unique for each message and each iteration of a message.
		/// If a message is updated, use a new <see cref="BlockId"/>.
		/// </summary>
		[JsonProperty("block_id")]
		public string BlockId { get; set; }
	}
}