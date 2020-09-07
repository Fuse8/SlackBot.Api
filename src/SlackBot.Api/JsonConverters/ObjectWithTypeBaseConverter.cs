using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using SlackBot.Api.Helpers;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.JsonConverters
{
	public class ObjectWithTypeBaseConverter<T> : SubclassConverter<T>
		where T : ObjectWithType
	{
		private readonly T[] _allObjects;
		private readonly string _typeJsonPropertyName;

		public ObjectWithTypeBaseConverter()
		{
			_allObjects = Subtypes.Select(objectType => (T) Activator.CreateInstance(objectType)).ToArray();
			_typeJsonPropertyName = typeof(T).GetProperty(nameof(ObjectWithType.Type)).GetJsonPropertyName();
		}

		protected override Type GetSubtypeToConvertTo(JObject jObject)
		{
			var jToken = jObject[_typeJsonPropertyName];
			return _allObjects.FirstOrDefault(p => p.Type == jToken?.Value<string>())?.GetType();
		}
	}
}