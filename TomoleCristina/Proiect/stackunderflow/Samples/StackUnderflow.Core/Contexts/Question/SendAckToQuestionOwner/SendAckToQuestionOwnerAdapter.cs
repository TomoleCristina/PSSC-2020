using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner;
using static StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner.SendAckToQuestionOwnerResult;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner
{
    class SendAckToQuestionOwnerAdapter : Adapter<SendAckToQuestionOwnerCmd, ISendAckToQuestionOwnerResult, QuestionWriteContext, QuestionDependencies>
    {
        public override Task PostConditions(SendAckToQuestionOwnerCmd cmd, ISendAckToQuestionOwnerResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendAckToQuestionOwnerResult> Work(SendAckToQuestionOwnerCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            return new AckSent(1,2);
        }
    }
}
