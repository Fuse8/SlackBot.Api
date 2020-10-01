using Newtonsoft.Json;

namespace SlackBot.Api.Clients
{
	public abstract class ObjectWithType : IObjectWithType
	{
		protected abstract string SectionType { get; }

		/// <summary>
		/// The type of block.
		/// </summary>
		[JsonProperty("type")]
		public string Type => SectionType;
	}
}