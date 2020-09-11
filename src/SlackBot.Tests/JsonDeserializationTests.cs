using System;
using NUnit.Framework;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models.Chat.PostMessage.Blocks;
using SlackBot.Api.Models.Chat.PostMessage.Contracts;
using SlackBot.Api.Models.Chat.PostMessage.Contracts.BlockElements;
using SlackBot.Api.Models.Chat.PostMessage.MessageObjects;

namespace SlackBot.Tests
{
	public class JsonDeserializationTests
	{
		[TestFixture(TypeArgs = new[] {typeof(BlockBase), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(IActionElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(IContextElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(IInputElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(ISectionElement), typeof(UnknownObject)})]
		[TestFixture(TypeArgs = new[] {typeof(TextObjectBase), typeof(UnknownTextObject)})]
		class JsonObjectWithUndeclaredTypeMustBeParseToUnknownObject<TParse, TExpected>
		{
			[Test]
			public void Test()
			{
				var json = @"{""type"":""some_undeclared_type""}";
				DeserializeAndCheckTypeOfResult<TParse, TExpected>(json);
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

		private static void DeserializeAndCheckTypeOfResult<TParse>(string json, Type expectedType)
		{
			var block = json.FromJson<TParse>();

			Assert.IsInstanceOf(expectedType, block);
		}

		private static void DeserializeAndCheckTypeOfResult<TParse, TExpected>(string json) => DeserializeAndCheckTypeOfResult<TParse>(json, typeof(TExpected));
	}
}