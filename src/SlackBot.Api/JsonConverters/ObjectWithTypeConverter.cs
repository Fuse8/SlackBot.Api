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
		where TUnknownType : T, IUnknownObjectWithType, new()
	{
		private readonly T[] _allObjects;
		private readonly string _typeJsonPropertyName;

		public ObjectWithTypeConverter()
		{
			_typeJsonPropertyName = typeof(IObjectWithType).GetProperty(nameof(IObjectWithType.Type)).GetJsonPropertyName();
			
			var convertSubtypesOfType = typeof(T);
			var unknownObjectType = typeof(IUnknownObjectWithType);

			var subtypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(domainAssembly => domainAssembly.GetTypes(), (domainAssembly, assemblyType) => assemblyType)
				.Where(
					classType => convertSubtypesOfType.IsAssignableFrom(classType) 
					             && !unknownObjectType.IsAssignableFrom(classType) 
					             && classType != convertSubtypesOfType 
					             && !classType.IsAbstract)
				.ToArray();
			
			_allObjects = subtypes.Select(objectType => (T) Activator.CreateInstance(objectType)).ToArray();
		}

		public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer) => throw new NotImplementedException();

		public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartObject)
			{
				var obj = JObject.Load(reader);
				var typeToParse = GetSubtypeToConvertTo(obj);

				if (typeToParse != null)
				{
					try
					{
						existingValue = (T) Activator.CreateInstance(typeToParse);
						serializer.Populate(obj.CreateReader(), existingValue);
					}
					catch 
					{
						existingValue = CreateUnknownObject(serializer, obj);	
					}
				}
				else
				{
					existingValue = CreateUnknownObject(serializer, obj);
				}
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

		private static TUnknownType CreateUnknownObject(JsonSerializer serializer, JObject jObject)
		{
			var unknownObject = new TUnknownType {Properties = new Dictionary<string, object>()};
			serializer.Populate(jObject.CreateReader(), unknownObject.Properties);
			return unknownObject;
		}
	}
}