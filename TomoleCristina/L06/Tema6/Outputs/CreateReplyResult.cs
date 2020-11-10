using System;
using System.Collections.Generic;
using System.Text;
using Tema6.Models;
using Tema6.Inputs;
using CSharp.Choices;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class CreateReplyResult
    {
        public interface ICreateReplyResult { }

        public class ReplyValid : ICreateReplyResult
        {
            public Reply Reply { get; }

            public ReplyValid(Reply reply)
            {
                Reply = reply;
            }
        }

        public class InvalidReply : ICreateReplyResult
        {
            public string Reasons { get; }

            public InvalidReply(string reasons)
            {
                Reasons = reasons;
            }
        }

        public class InvalidRequest : ICreateReplyResult
        {
            public string ValidationErrors { get; }
            public InvalidRequest(string validationErrors)
            {
                ValidationErrors = validationErrors;
            }
        }

    }
}
