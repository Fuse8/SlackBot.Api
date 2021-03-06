﻿using System;
using System.Collections.Generic;
using SlackBot.Api;

namespace SlackBot.Tests.PostMessageTests
{
	internal static class PostMessageSerializationCases
	{
		public static object[] MessageCases =
		{
			new object[]
			{
				new SlackMessage
				{
					ChannelIdOrName = "channel",
					Attachments = new List<Attachment>(),
					Blocks = new List<BlockBase>(),
					Parse = "full",
					Text = "text",
					Username = "username",
					AsUser = true,
					IconEmoji = ":IconEmoji:",
					IconUrl = new Uri("http://iconurl"),
					LinkNames = true,
					ReplyBroadcast = true,
					ThreadTimestamp = "1234567489.011",
					UnfurlLinks = true,
					UnfurlMedia = true,
					UseMarkdown = true
				},
				@"{""channel"":""channel"",""attachments"":[],""blocks"":[],""parse"":""full"",""text"":""text"",""username"":""username"",""as_user"":true,""icon_emoji"":"":IconEmoji:"",""icon_url"":""http://iconurl"",""link_names"":true,""reply_broadcast"":true,""thread_ts"":""1234567489.011"",""unfurl_links"":true,""unfurl_media"":true,""mrkdwn"":true}"
			},
		};

		public static object[] BlockCases =
		{
			new object[]
			{
				new ActionBlock
				{
					Elements = new List<IActionElement>(),
					BlockId = "BlockId"
				},
				@"{""type"":""actions"",""elements"":[],""block_id"":""BlockId""}"
			},
			new object[]
			{
				new ContextBlock
				{
					Elements = new List<IContextElement>(),
					BlockId = "BlockId"
				},
				@"{""type"":""context"",""elements"":[],""block_id"":""BlockId""}"
			},
			new object[]
			{
				new DividerBlock
				{
					BlockId = "BlockId"
				},
				@"{""type"":""divider"",""block_id"":""BlockId""}"
			},
			new object[]
			{
				new FileBlock
				{
					BlockId = "BlockId",
					ExternalId = "ExternalId",
					Source = "Source"
				},
				@"{""type"":""file"",""block_id"":""BlockId"",""external_id"":""ExternalId"",""source"":""Source""}"
			},
			new object[]
			{
				new HeaderBlock
				{
					BlockId = "BlockId",
					Text = new PlainTextObject(),
				},
				@"{""type"":""header"",""block_id"":""BlockId"",""text"":{""type"":""plain_text""}}"
			},
			new object[]
			{
				new ImageBlock
				{
					BlockId = "BlockId",
					Title = new PlainTextObject(),
					AltText = "AltText",
					ImageUrl = new Uri("http://iconurl")
				},
				@"{""type"":""image"",""block_id"":""BlockId"",""title"":{""type"":""plain_text""},""alt_text"":""AltText"",""image_url"":""http://iconurl""}"
			},
			new object[]
			{
				new SectionBlock
				{
					BlockId = "BlockId",
					Accessory = new ImageElement(),
					Fields = new List<TextObjectBase>(),
					Text = new PlainTextObject()
				},
				@"{""type"":""section"",""text"":{""type"":""plain_text""},""block_id"":""BlockId"",""fields"":[],""accessory"":{""type"":""image""}}"
			},
		};

		public static object[] ElementCases =
		{
			new object[]
			{
				new ButtonActionElement
				{
					Style = StyleType.Danger,
					Confirm = new ConfirmationDialogObject(),
					Text = new PlainTextObject(),
					Url = new Uri("http://iconurl"),
					Value = "Value",
					ActionId = "ActionId"
				},
				@"{""type"":""button"",""text"":{""type"":""plain_text""},""action_id"":""ActionId"",""url"":""http://iconurl"",""value"":""Value"",""style"":""danger"",""confirm"":{}}"
			},
			new object[]
			{
				new DatepickerActionElement
				{
					Placeholder = new PlainTextObject(),
					Confirm = new ConfirmationDialogObject(),
					InitialDate = "2020-02-02",
					ActionId = "ActionId"
				},
				@"{""type"":""datepicker"",""action_id"":""ActionId"",""placeholder"":{""type"":""plain_text""},""initial_date"":""2020-02-02"",""confirm"":{}}"
			},
			new object[]
			{
				new ImageElement
				{
					AltText = "AltText",
					ImageUrl = new Uri("http://iconurl")
				},
				@"{""type"":""image"",""image_url"":""http://iconurl"",""alt_text"":""AltText""}"
			},
			new object[]
			{
				new MultiSelectActionElement
				{
					Confirm = new ConfirmationDialogObject(),
					Options = new List<OptionObject>(),
					Placeholder = new PlainTextObject(),
					ActionId = "ActionId",
					InitialOptions = new List<OptionObject>(),
					OptionGroups = new List<OptionGroupObject>(),
					MaxSelectedItems = 25
				},
				@"{""type"":""multi_static_select"",""placeholder"":{""type"":""plain_text""},""action_id"":""ActionId"",""options"":[],""option_groups"":[],""initial_options"":[],""confirm"":{},""max_selected_items"":25}"
			},
		};

		public static object[] MessageObjectCases =
		{
			new object[]
			{
				new MarkdownTextObject
				{
					Text = "Text",
					Verbatim = true
				},
				@"{""type"":""mrkdwn"",""text"":""Text"",""verbatim"":true}"
			},
			new object[]
			{
				new PlainTextObject
				{
					Text = "Text",
					UseEmoji = true
				},
				@"{""type"":""plain_text"",""text"":""Text"",""emoji"":true}"
			},
			new object[]
			{
				new ConfirmationDialogObject
				{
					Title = new PlainTextObject(),
					Text = new PlainTextObject(),
					Confirm = new PlainTextObject(),
					Deny = new PlainTextObject(),
					Style = StyleType.Danger
				},
				@"{""title"":{""type"":""plain_text""},""text"":{""type"":""plain_text""},""confirm"":{""type"":""plain_text""},""deny"":{""type"":""plain_text""},""style"":""danger""}"
			},
			new object[]
			{
				new OptionObject
				{
					Text = new PlainTextObject(),
					Value = "Value",
					Description = new PlainTextObject(),
					Url = new Uri("http://iconurl")
				},
				@"{""text"":{""type"":""plain_text""},""description"":{""type"":""plain_text""},""value"":""Value"",""url"":""http://iconurl""}"
			},
			new object[]
			{
				new OptionGroupObject
				{
					Label = new PlainTextObject(),
					Options = new List<OptionObject>()
				},
				@"{""label"":{""type"":""plain_text""},""options"":[]}"
			}
		};
	}
}