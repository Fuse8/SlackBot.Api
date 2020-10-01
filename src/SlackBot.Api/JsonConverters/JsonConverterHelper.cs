using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Clients.PostMessage.Contracts;
using SlackBot.Api.Clients.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Clients.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Api.JsonConverters
{
	internal static class JsonConverterHelper
	{
		public static IEnumerable<JsonConverter> GetSpecificClassConverters()
			=> new JsonConverter[]
			{
				new ObjectWithTypeConverter<BlockBase, UnknownObject>(),
				new ObjectWithTypeConverter<TextObjectBase, UnknownTextObject>(),
				new ObjectWithTypeConverter<IActionElement, UnknownObject>(),
				new ObjectWithTypeConverter<IContextElement, UnknownObject>(),
				new ObjectWithTypeConverter<IInputElement, UnknownObject>(),
				new ObjectWithTypeConverter<ISectionElement, UnknownObject>(),
			};
	}
}