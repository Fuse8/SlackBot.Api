using System;
using SlackBot.Api.Clients.GeneralObjects;
using SlackBot.Api.Enums;
using SlackBot.Api.Extensions;

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
				Errors = parsedError.Errors;
			}
		}

        public string Error { get; }
        
        public string Warning { get; }
		
		public object Metadata { get; }
		
		public object Errors { get; }
	}
}