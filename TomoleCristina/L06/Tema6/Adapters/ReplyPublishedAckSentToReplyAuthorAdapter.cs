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

    class ReplyPublishedAckSentToReplyAuthorAdapter : Adapter<ReplyPublishedAckSentToReplyAuthorCmd, ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult, QuestionWriteContext>
    {
        public override Task PostConditions(ReplyPublishedAckSentToReplyAuthorCmd cmd, ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public override async Task<ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult> Work(ReplyPublishedAckSentToReplyAuthorCmd cmd, QuestionWriteContext state)
        {
            var wf = from isValid in cmd.TryValidate()
                     from ackSentToReplyAuthor in AckSentToReplyAuthor(cmd, state)
                     select ackSentToReplyAuthor;
            return await wf.Match(
                  Succ: ReplyAuthor => ReplyAuthor,
                  Fail: ex => new ReplyPublishedAckSentToReplyAuthorResult.InvalidReplyPublished(ex.ToString()));
        }
        private TryAsync<ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult> AckSentToReplyAuthor(ReplyPublishedAckSentToReplyAuthorCmd cmd, QuestionWriteContext state)
        {

            return TryAsync<ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult>(async () =>
            {
                return new ReplyPublishedAckSentToReplyAuthorResult.ReplyPublished(cmd.Reply);
            });
        }
    }
}
