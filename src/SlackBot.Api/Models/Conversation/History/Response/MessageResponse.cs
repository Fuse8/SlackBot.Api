using System.Collections.Generic;
using Newtonsoft.Json;
using SlackBot.Api.Models.GeneralObjects;
using SlackBot.Api.Models.GeneralObjects.BotInfo;

namespace SlackBot.Api.Models.Conversation.History.Response
{
    public class MessageResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("subtype")]
        public string Subtype { get; set; }
        
        [JsonProperty("hidden")]
        public bool? Hidden { get; set; }
        
        [JsonProperty("is_starred")]
        public bool? IsStarred { get; set; }
        
        [JsonProperty("pinned_to")]
        public List<string> PinnedToChannelIds { get; set; }
        
        [JsonProperty("pinned_info")]
        public PinnedInfo PinnedInfo { get; set; }
        
        [JsonProperty("reactions")]
        public List<MessageReactionItem> Reactions { get; set; }
        
        [JsonProperty("channel")]
        public string ChannelId { get; set; }
        
        [JsonProperty("user")]
        public string UserId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ts")]
        public string Timestamp { get; set; }

        [JsonProperty("edited")]
        public MessageEditedInfo EditedInfo { get; set; }

        [JsonProperty("blocks")]
        public object[] Blocks { get; set; } //TODO возможно заюзать базовый тип или сделать свой для респонса с типом блока и его айдихой

        [JsonProperty("team")]
        public string TeamId { get; set; }
        
        [JsonProperty("display_as_bot")]
        public bool? DisplayAsBot { get; set; }
        
        [JsonProperty("bot_id")]
        public string BotId { get; set; }

        [JsonProperty("bot_profile")]
        public BotInfo BotInfo { get; set; }
        
        [JsonProperty("files")]
        public List<SlackFile> Files { get; set; }
        
        [JsonProperty("thread_ts")]
        public string ThreadTimestamp { get; set; }
        
        [JsonProperty("reply_count")]
        public long? ReplyCount { get; set; }
        
        [JsonProperty("reply_users_count")]
        public long? ReplyUsersCount { get; set; }
        
        [JsonProperty("latest_reply")]
        public string LatestReplyTimestamp { get; set; }
        
        [JsonProperty("reply_users")]
        public List<string> ReplyUserIds { get; set; }
        
        [JsonProperty("subscribed")]
        public bool? Subscribed { get; set; }
        
        [JsonProperty("upload")]
        public bool? Upload { get; set; }
        
        [JsonProperty("client_msg_id")]
        public string ClientMessageIdGuid { get; set; }
        
        #region "bot_message" type

        [JsonProperty("username")]
        public string Username { get; set; }

        #endregion
        
        #region "channel_join" type
        
        [JsonProperty("inviter")]
        public string InviterId { get; set; }

        #endregion
        
        #region "channel_name" and "group_name" type
        
        [JsonProperty("old_name")]
        public string OldName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        #endregion
        
        #region "channel_purpose" and "group_purpose" type
        
        [JsonProperty("purpose")]
        public string PurposeText { get; set; }

        #endregion
        
        #region "channel_topic" and "group_topic" type
        
        [JsonProperty("topic")]
        public string TopicText { get; set; }

        #endregion
        
        #region "file_comment" and "file_mention" type
        
        [JsonProperty("file")]
        public SlackFile File { get; set; }
        
        #endregion
        
        #region "file_comment" type
        
        [JsonProperty("comment")]
        public object Comment { get; set; } //TODO

        #endregion
        
        #region "group_archive" type
        
        [JsonProperty("members")]
        public List<string> MemberIds { get; set; }

        #endregion
        
        #region "message_changed" and "message_replied" type
        
        [JsonProperty("message")]
        public MessageResponse UpdatedMessage { get; set; }

        #endregion
        
        #region "message_deleted" type
        
        [JsonProperty("deleted_ts")]
        public string DeletedTimestamp { get; set; }

        #endregion
        
        #region "message_replied" type
        
        [JsonProperty("event_ts")]
        public string EventTimestamp { get; set; }

        #endregion
        
        #region "pinned_item" and "unpinned_item" type
        
        [JsonProperty("item_type")]
        public string ItemType { get; set; }
        
        [JsonProperty("item")]
        public object Item { get; set; }  //TODO

        #endregion
        
        #region "file_share" type
        
        [JsonProperty("channel_type")]
        public string ChannelType { get; set; }

        #endregion
        
        #region "thread_broadcast" type
        
        [JsonProperty("root")]
        public MessageResponse RootMessage { get; set; }

        #endregion
    }
}