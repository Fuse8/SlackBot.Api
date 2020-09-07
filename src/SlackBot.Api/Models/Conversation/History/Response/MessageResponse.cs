using System.Collections.Generic;
using System.Text.Json.Serialization;
using SlackBot.Api.Models.GeneralObjects;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class MessageResponse
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("subtype")]
        public string Subtype { get; set; }
        
        [JsonPropertyName("hidden")]
        public bool? Hidden { get; set; }
        
        [JsonPropertyName("is_starred")]
        public bool? IsStarred { get; set; }
        
        [JsonPropertyName("pinned_to")]
        public List<string> PinnedToChannelIds { get; set; }
        
        [JsonPropertyName("pinned_info")]
        public PinnedInfo PinnedInfo { get; set; }
        
        [JsonPropertyName("reactions")]
        public List<MessageReactionItem> Reactions { get; set; }
        
        [JsonPropertyName("channel")]
        public string ChannelId { get; set; }
        
        [JsonPropertyName("user")]
        public string UserId { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("ts")]
        public string Timestamp { get; set; }

        [JsonPropertyName("edited")]
        public MessageEditedInfo EditedInfo { get; set; }

        [JsonPropertyName("blocks")]
        public object[] Blocks { get; set; } //TODO возможно заюзать базовый тип или сделать свой для респонса с типом блока и его айдихой

        [JsonPropertyName("team")]
        public string TeamId { get; set; }
        
        [JsonPropertyName("display_as_bot")]
        public bool? DisplayAsBot { get; set; }
        
        [JsonPropertyName("bot_id")]
        public string BotId { get; set; }

        [JsonPropertyName("bot_profile")]
        public BotInfo BotInfo { get; set; }
        
        [JsonPropertyName("files")]
        public List<SlackFile> Files { get; set; }
        
        [JsonPropertyName("thread_ts")]
        public string ThreadTimestamp { get; set; }
        
        [JsonPropertyName("reply_count")]
        public long? ReplyCount { get; set; }
        
        [JsonPropertyName("reply_users_count")]
        public long? ReplyUsersCount { get; set; }
        
        [JsonPropertyName("latest_reply")]
        public string LatestReplyTimestamp { get; set; }
        
        [JsonPropertyName("reply_users")]
        public List<string> ReplyUserIds { get; set; }
        
        [JsonPropertyName("subscribed")]
        public bool? Subscribed { get; set; }
        
        [JsonPropertyName("upload")]
        public bool? Upload { get; set; }
        
        [JsonPropertyName("client_msg_id")]
        public string ClientMessageIdGuid { get; set; }
        
        #region "bot_message" type

        [JsonPropertyName("username")]
        public string Username { get; set; }

        #endregion
        
        #region "channel_join" type
        
        [JsonPropertyName("inviter")]
        public string InviterId { get; set; }

        #endregion
        
        #region "channel_name" and "group_name" type
        
        [JsonPropertyName("old_name")]
        public string OldName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        #endregion
        
        #region "channel_purpose" and "group_purpose" type
        
        [JsonPropertyName("purpose")]
        public string PurposeText { get; set; }

        #endregion
        
        #region "channel_topic" and "group_topic" type
        
        [JsonPropertyName("topic")]
        public string TopicText { get; set; }

        #endregion
        
        #region "file_comment" and "file_mention" type
        
        [JsonPropertyName("file")]
        public SlackFile File { get; set; }
        
        #endregion
        
        #region "file_comment" type
        
        [JsonPropertyName("comment")]
        public object Comment { get; set; } //TODO

        #endregion
        
        #region "group_archive" type
        
        [JsonPropertyName("members")]
        public List<string> MemberIds { get; set; }

        #endregion
        
        #region "message_changed" and "message_replied" type
        
        [JsonPropertyName("message")]
        public MessageResponse UpdatedMessage { get; set; }

        #endregion
        
        #region "message_deleted" type
        
        [JsonPropertyName("deleted_ts")]
        public string DeletedTimestamp { get; set; }

        #endregion
        
        #region "message_replied" type
        
        [JsonPropertyName("event_ts")]
        public string EventTimestamp { get; set; }

        #endregion
        
        #region "pinned_item" and "unpinned_item" type
        
        [JsonPropertyName("item_type")]
        public string ItemType { get; set; }
        
        [JsonPropertyName("item")]
        public object Item { get; set; }  //TODO

        #endregion
        
        #region "file_share" type
        
        [JsonPropertyName("channel_type")]
        public string ChannelType { get; set; }

        #endregion
        
        #region "thread_broadcast" type
        
        [JsonPropertyName("root")]
        public MessageResponse RootMessage { get; set; }

        #endregion
    }
}