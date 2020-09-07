using SlackBot.Api.Attributes;

namespace SlackBot.Api.Models.GeneralObjects.Pagination
{
    public abstract class CursorPaginationBase
    {
        [FormPropertyName("cursor")]
        public string Cursor { get; set; }
    }
}