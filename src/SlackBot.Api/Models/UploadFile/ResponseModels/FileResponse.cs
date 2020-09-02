using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SlackBot.Api.Models.UploadFile.ResponseModels
{
    public class FileResponse
    {
         [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("created")]
        public int Created { get; set; } 

        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; } 

        [JsonPropertyName("name")]
        public string Name { get; set; } 

        [JsonPropertyName("title")]
        public string Title { get; set; } 

        [JsonPropertyName("mimetype")]
        public string Mimetype { get; set; } 

        [JsonPropertyName("filetype")]
        public string Filetype { get; set; } 

        [JsonPropertyName("pretty_type")]
        public string PrettyType { get; set; } 

        [JsonPropertyName("user")]
        public string User { get; set; } 

        [JsonPropertyName("editable")]
        public bool Editable { get; set; } 

        [JsonPropertyName("size")]
        public int Size { get; set; } 

        [JsonPropertyName("mode")]
        public string Mode { get; set; } 

        [JsonPropertyName("is_external")]
        public bool IsExternal { get; set; } 

        [JsonPropertyName("external_type")]
        public string ExternalType { get; set; } 

        [JsonPropertyName("is_public")]
        public bool IsPublic { get; set; } 

        [JsonPropertyName("public_url_shared")]
        public bool PublicUrlShared { get; set; } 

        [JsonPropertyName("display_as_bot")]
        public bool DisplayAsBot { get; set; } 

        [JsonPropertyName("username")]
        public string Username { get; set; } 

        [JsonPropertyName("url_private")]
        public string UrlPrivate { get; set; } 

        [JsonPropertyName("url_private_download")]
        public string UrlPrivateDownload { get; set; } 

        [JsonPropertyName("thumb_64")]
        public string Thumb64 { get; set; } 

        [JsonPropertyName("thumb_80")]
        public string Thumb80 { get; set; } 

        [JsonPropertyName("thumb_360")]
        public string Thumb360 { get; set; } 

        [JsonPropertyName("thumb_360_w")]
        public int Thumb360W { get; set; } 

        [JsonPropertyName("thumb_360_h")]
        public int Thumb360H { get; set; } 

        [JsonPropertyName("thumb_480")]
        public string Thumb480 { get; set; } 

        [JsonPropertyName("thumb_480_w")]
        public int Thumb480W { get; set; } 

        [JsonPropertyName("thumb_480_h")]
        public int Thumb480H { get; set; } 

        [JsonPropertyName("thumb_160")]
        public string Thumb160 { get; set; } 

        [JsonPropertyName("image_exif_rotation")]
        public int ImageExifRotation { get; set; } 

        [JsonPropertyName("original_w")]
        public int OriginalW { get; set; } 

        [JsonPropertyName("original_h")]
        public int OriginalH { get; set; } 

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; } 

        [JsonPropertyName("permalink_public")]
        public string PermalinkPublic { get; set; } 

        [JsonPropertyName("comments_count")]
        public int CommentsCount { get; set; } 

        [JsonPropertyName("is_starred")]
        public bool IsStarred { get; set; } 

        [JsonPropertyName("shares")]
        public object Shares { get; set; } //TODO придумать что с шарой делать

        [JsonPropertyName("channels")]
        public List<object> Channels { get; set; } 

        [JsonPropertyName("groups")]
        public List<object> Groups { get; set; } 

        [JsonPropertyName("ims")]
        public List<string> Ims { get; set; } 

        [JsonPropertyName("has_rich_preview")]
        public bool HasRichPreview { get; set; }
    }
}