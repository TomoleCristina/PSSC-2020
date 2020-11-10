using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class ReplyPublishedAckSentToReplyAuthorResult
    {
        public interface IReplyPublishedAckSentToReplyAuthorResult { };
        public class ReplyPublished : IReplyPublishedAckSentToReplyAuthorResult
        {
            public string ConfirmationMessage { get; }
            public ReplyPublished(string confirmationMessage)
            {
                ConfirmationMessage = confirmationMessage;
            }
        }
        public class InvalidReplyPublished : IReplyPublishedAckSentToReplyAuthorResult
        {
            public string ErrorMessage { get; }
            public InvalidReplyPublished(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
    }
}