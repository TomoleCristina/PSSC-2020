﻿using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage;
using static StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage.CheckLanguageResult;

namespace StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage
{
    public class CheckLanguageAdapter : Adapter<CheckLanguageCmd, ICheckLanguageResult, QuestionWriteContext, QuestionDependencies>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICheckLanguageResult> Work(CheckLanguageCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            return new TextChecked("Valid");
        }
    }
}
