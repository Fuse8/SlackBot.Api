using System;
using Newtonsoft.Json;
using SlackBot.Api.Extensions;
using SlackBot.Api.Models;

namespace SlackBot.Api.Exceptions
{
    public class SlackApiResponseException : ApplicationException
    {
        public SlackApiResponseException(string errorResponseString)
            : base($"Incorrect Slack API request: {errorResponseString}")
        {
            ApiError = errorResponseString.FromJson<SlackErrorResponse>(); //TODO подумать, что сделать, если при десереализации упадет ошибка. Наверное нужно сделать хелпер для Json
        }

        public SlackErrorResponse ApiError { get; set; } //TODO сделать спец класс для полей ошибки
    }
}