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
            var parsedError = errorResponseString.FromJson<SlackErrorResponse>(ExceptionHandlingMode.DoNotProcess);
            if (parsedError != null)
            {
                Error = parsedError.Error;
                Warning = parsedError.Warning;
				Metadata = parsedError.Metadata;
			}
		}

        public string Error { get; }
        
        public string Warning { get; }
		
		public object Metadata { get; }
	}
}