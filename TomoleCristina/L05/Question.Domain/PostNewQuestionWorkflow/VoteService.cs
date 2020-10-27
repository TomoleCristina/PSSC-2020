using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.PostNewQuestionWorkflow.PostNewQuestionResult;
using static Question.Domain.PostNewQuestionWorkflow.VerifyQuestionDescription;

namespace Question.Domain.PostNewQuestionWorkflow
{
    public class VoteService
    {
        //verificarea voturilor
        public Task Vote(VerifiedQuestionDescription question)
        {
            return Task.CompletedTask;
        }
    }
}
