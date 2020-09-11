using System;
using SlackBot.Api.Enums;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models;

namespace SlackBot.Api.Exceptions
{
    public class SlackApiResponseException : ApplicationException
    {
        public SlackApiResponseException(string errorResponseString)
            : base($"Incorrect Slack API request: {errorResponseString}")
        {
            ApiError = errorResponseString.FromJson<SlackErrorResponse>(exceptionHandlingMode: ExceptionHandlingMode.DoNotProcess); 
        }

        public SlackErrorResponse ApiError { get; set; } //TODO сделать спец класс для полей ошибки
    }
}