using System;
using NUnit.Framework;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models.Chat.PostMessage.Blocks;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects.TextObjects;

namespace SlackBot.Tests
{
	internal class JsonDeserializationTests
	{
		[TestFixture(TypeArgs = new[] {typeof(BlockBase), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(IActionElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(IContextElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(IInputElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(ISectionElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(TextObjectBase), typeof(UnknownTextObject)})]
		class ParseToUnknownObjectTests<TParse, TExpected>
			where TExpected : IUnknownObjectWithType, TParse
		{
			[Test]
			public void JsonObjectWithUndeclaredTypeMustBeParseToUnknownObject()
			{
				var json = @"{""type"":""some_undeclared_type""}";
				DeserializeAndCheckTypeOfResult<TParse, TExpected>(json);
			}
			
			[Test]
			public void JsonObjectWithoutTypeMustBeParseToUnknownObject()
			{
				var json = @"{""msg"":""object_without_type""}";
				DeserializeAndCheckTypeOfResult<TParse, TExpected>(json);
			}
			
			[Test]
			public void JsonObjectPropertiesMustBeContainedInUnknownObject()
			{
				var json = @"{""msg"":""message""}";
				
				var parsedObject = json.FromJson<TParse>();
				var unknownObjectWithType = (TExpected)parsedObject;
				var properties = unknownObjectWithType.Properties;
				
				Assert.IsTrue(properties.ContainsKey("msg"));
				Assert.AreEqual(properties["msg"], "message");
			}
		}
		
		[TestCase("actions", typeof(ActionBlock))]
		[TestCase("context", typeof(ContextBlock))]
		[TestCase("divider", typeof(DividerBlock))]
		[TestCase("file", typeof(FileBlock))]
		[TestCase("header", typeof(HeaderBlock))]
		[TestCase("image", typeof(ImageBlock))]
		[TestCase("section", typeof(SectionBlock))]
		public void JsonObjectWithKnownTypeMustBeParseToThatObject(string typeInJson, Type expectedType)
		{
			var json = $@"{{""type"":""{typeInJson}""}}";
			
			DeserializeAndCheckTypeOfResult<BlockBase>(json, expectedType);
		}

		private static void DeserializeAndCheckTypeOfResult<TParse, TExpected>(string json) 
			=> DeserializeAndCheckTypeOfResult<TParse>(json, typeof(TExpected));

		private static void DeserializeAndCheckTypeOfResult<TParse>(string json, Type expectedType)
		{
			var result = json.FromJson<TParse>();

			Assert.IsInstanceOf(expectedType, result);
		}
	}
}