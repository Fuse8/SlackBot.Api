using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;

namespace SlackBot.Api.JsonConverters
{
	public static class JsonConverterHelper
	{
		public static IEnumerable<JsonConverter> GetSpecificClassConverters() =>
			new JsonConverter[]
			{
				new ObjectWithTypeBaseConverter<BlockBase>(),
				new ObjectWithTypeBaseConverter<TextObjectBase>(),
				new SubclassConverter<IActionElement>(),
				new SubclassConverter<IContextElement>(),
				new SubclassConverter<IInputElement>(),
				new SubclassConverter<ISectionElement>(),
			};
	}
}