using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt;
using LanguageExt.Common;

namespace Question.Domain.PostNewQuestionWorkflow
{
    [AsChoice]
    public static partial class VerifyQuestionDescription
    {
        public interface IQuestionDescription { }
        public class UnverifiedQuestionDescription : IQuestionDescription
        {
            public string Question { get; private set; }
            public List<string> Tags { get; private set; }
            private UnverifiedQuestionDescription(string question, List<string> tags)
            {
                Question = question;
                Tags = tags;
            }
            public static Result<UnverifiedQuestionDescription> Create(string question, List<string> tags)
            {
                if (ValidQuestion(question))
                {
                    if (ValidTags(tags))
                    {
                        return new UnverifiedQuestionDescription(question, tags);
                    }
                    else
                    {
                        return new Result<UnverifiedQuestionDescription>(new InvalidTagsException(tags));
                    }
                }
                else
                    return new Result<UnverifiedQuestionDescription>(new InvalidQuestionException(question));
            }
            private static bool ValidQuestion(string question)
            {
                if (question.Length <= 1000)
                {
                    return true;
                }
                return false;
            }
            private static bool ValidTags(List<string> tags)
            {
                if (tags.Count >= 1 && tags.Count <= 3)
                {
                    return true;
                }
                return false;
            }
        }
            public class VerifiedQuestionDescription : IQuestionDescription
            {
                public string Question { get; private set; }
                public List<string> Tags { get; private set; }
                internal VerifiedQuestionDescription(string question, List<string> tags)
                {
                    Question = question;
                    Tags = tags;
                }
            }
    }
}
