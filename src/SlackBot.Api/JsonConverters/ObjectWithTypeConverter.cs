using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SlackBot.Api.Helpers;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;

namespace SlackBot.Api.JsonConverters
{
	internal class ObjectWithTypeConverter<T, TUnknownType> : JsonConverter<T>
		where T : class, IObjectWithType
		where TUnknownType : T, IUnknownObjectWithType, new()
	{
		private readonly T[] _allObjects;
		private readonly string _typeJsonPropertyName;

		public ObjectWithTypeConverter()
		{
			_typeJsonPropertyName = typeof(ObjectWithType).GetProperty(nameof(ObjectWithType.Type)).GetJsonPropertyName();

			var subtypes = GetSubtypes();

			_allObjects = subtypes.Select(objectType => (T)Activator.CreateInstance(objectType)).ToArray();
		}

		public override bool CanRead => true;

		public override bool CanWrite => false;

		private static Type[] GetSubtypes()
		{
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
			return subtypes;
		}

		public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
			=> throw new NotImplementedException();

		public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.StartObject)
			{
				var objToParse = JObject.Load(reader);
				var typeToParse = GetSubtypeToConvertTo(objToParse);

				if (typeToParse != null)
				{
					try
					{
						existingValue = (T)Activator.CreateInstance(typeToParse);
						serializer.Populate(objToParse.CreateReader(), existingValue);
					}
					catch
					{
						existingValue = CreateUnknownObject(serializer, objToParse);
					}
				}
				else
				{
					existingValue = CreateUnknownObject(serializer, objToParse);
				}
			}

			return existingValue;
		}

		private Type GetSubtypeToConvertTo(JObject jObject)
		{
			var objectTypeValue = jObject[_typeJsonPropertyName]?.Value<string>();
			return _allObjects.FirstOrDefault(p => p.Type == objectTypeValue)?.GetType();
		}

		private static TUnknownType CreateUnknownObject(JsonSerializer serializer, JObject jObject)
		{
			var unknownObject = new TUnknownType { Properties = new Dictionary<string, object>() };
			serializer.Populate(jObject.CreateReader(), unknownObject.Properties);
			return unknownObject;
		}
	}
}