using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion.CreateQuestionResult;
using static StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage.CheckLanguageResult;
using static StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner.SendAckToQuestionOwnerResult;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public static class QuestionContext
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd createQuestionCmd) =>
            NewPort<CreateQuestionCmd, ICreateQuestionResult>(createQuestionCmd);
       
        public static Port<ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd) =>
           NewPort<CheckLanguageCmd, ICheckLanguageResult>(checkLanguageCmd);

        public static Port<ISendAckToQuestionOwnerResult> SendAckToQuestionOwner(SendAckToQuestionOwnerCmd sendAckToQuestionOwnerCmd) =>
            NewPort<SendAckToQuestionOwnerCmd, ISendAckToQuestionOwnerResult>(sendAckToQuestionOwnerCmd);
    }
}
