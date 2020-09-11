using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackBot.Api.Helpers;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.JsonConverters
{
	public class ObjectWithTypeConverter<T, TUnknownType> : JsonConverter<T>
		where T : class, IObjectWithType
		where TUnknownType : T, IUnknownObjectWithType
	{
		private readonly T[] _allObjects;
		private readonly string _typeJsonPropertyName;

		public ObjectWithTypeConverter()
		{
			_typeJsonPropertyName = typeof(IObjectWithType).GetProperty(nameof(IObjectWithType.Type)).GetJsonPropertyName();
			
			var convertSubtypesOfType = typeof(T);

			var subtypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(domainAssembly => domainAssembly.GetTypes(), (domainAssembly, assemblyType) => assemblyType)
				.Where(t => convertSubtypesOfType.IsAssignableFrom(t) && t != convertSubtypesOfType && !t.IsAbstract)
				.ToArray();
			
			_allObjects = subtypes.Select(objectType => (T) Activator.CreateInstance(objectType)).ToArray();
		}

		public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer) => throw new NotImplementedException();

		public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartObject)
				return existingValue;
			var obj = JObject.Load(reader);
			objectType = GetSubtypeToConvertTo(obj);

			if (objectType != null)
			{
				existingValue = (T) Activator.CreateInstance(objectType);
				serializer.Populate(obj.CreateReader(), existingValue);
			}
			else
			{
				var unknownObject = (TUnknownType) Activator.CreateInstance(typeof(TUnknownType));
				unknownObject.Properties = new Dictionary<string, object>();
				serializer.Populate(obj.CreateReader(), unknownObject.Properties);
				
				existingValue = unknownObject;
			}
			
			return existingValue;
		}
		
		public override bool CanRead => true;
		public override bool CanWrite => false;

		private Type GetSubtypeToConvertTo(JObject jObject)
		{
			var jToken = jObject[_typeJsonPropertyName];
			return _allObjects.FirstOrDefault(p => p.Type == jToken?.Value<string>())?.GetType();
		}
	}
}