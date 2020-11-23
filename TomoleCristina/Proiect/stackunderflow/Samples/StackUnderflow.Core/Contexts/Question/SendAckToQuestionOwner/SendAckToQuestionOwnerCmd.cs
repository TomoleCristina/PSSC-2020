using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner
{
    public class SendAckToQuestionOwnerCmd
    {
        public int QuestionId { get; }
        public int QuestionOwnerId { get; }
        public SendAckToQuestionOwnerCmd(int questionId, int questionOwnerId)
        {
            QuestionId = questionId;
            QuestionOwnerId = questionOwnerId;
        }
    }
}
