using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using LanguageExt;
using Tema6.Inputs;
using Tema6.Models;
using Tema6.Outputs;
using static LanguageExt.Prelude;

namespace Tema6.Adapters
{
    class ReplyReceivedAckSentToQuestionOwnerAdapter : Adapter<ReplyReceivedAckSentToQuestionOwnerCmd, ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult, QuestionWriteContext>
    {
        public override Task PostConditions(ReplyReceivedAckSentToQuestionOwnerCmd cmd, ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task<ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult> Work(ReplyReceivedAckSentToQuestionOwnerCmd cmd, QuestionWriteContext state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from ownerAck in OwnerAckResult(cmd, state)
                     select ownerAck;
            return await wf.Match(
                  Succ: owner => owner,
                  Fail: ex => new ReplyReceivedAckSentToQuestionOwnerResult.InvalidReplyReceived(ex.ToString()));
        }
        private TryAsync<ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult> OwnerAckResult(ReplyReceivedAckSentToQuestionOwnerCmd cmd, QuestionWriteContext state)
        {

            return TryAsync<ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult>(async () =>
            {
                return new ReplyReceivedAckSentToQuestionOwnerResult.ReplyReceived(cmd.Reply);
            });
        }
    }
}
