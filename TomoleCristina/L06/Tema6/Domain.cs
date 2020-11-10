using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;
using Tema6.Inputs;
using Tema6.Outputs;
using static PortExt;

namespace Tema6
{
    public static class BoundedContextDSL
    {

        /// <summary>
        /// CreateReplyCmd -> ICreateReplyResult
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="userId"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public static Port<CreateReplyResult.ICreateReplyResult> ValidateReply(int questionId, int userId, string answer)
            => NewPort<CreateReplyCmd, CreateReplyResult.ICreateReplyResult>(new CreateReplyCmd(userId, questionId, answer));

        public static Port<CheckLanguageResult.ICheckLanguageResult> CheckLanguage(string text)
            => NewPort<CheckLanguageCmd, CheckLanguageResult.ICheckLanguageResult>(new CheckLanguageCmd(text));

        public static Port<ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult> SendAckToQuestionOwner(int authorid, int questionid, string reply)
         => NewPort<ReplyReceivedAckSentToQuestionOwnerCmd, ReplyReceivedAckSentToQuestionOwnerResult.IReplyReceivedAckSentToQuestionOwnerResult>(new ReplyReceivedAckSentToQuestionOwnerCmd(authorid, questionid, reply));

        public static Port<ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult> SendAckToReplyAuthor(int replyid, int questionid, string reply)
        => NewPort<ReplyPublishedAckSentToReplyAuthorCmd, ReplyPublishedAckSentToReplyAuthorResult.IReplyPublishedAckSentToReplyAuthorResult>(new ReplyPublishedAckSentToReplyAuthorCmd(replyid, questionid, reply));
    }
}
