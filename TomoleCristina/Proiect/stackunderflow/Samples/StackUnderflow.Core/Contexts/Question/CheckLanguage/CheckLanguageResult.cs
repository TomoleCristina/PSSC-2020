using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage
{
    [AsChoice]
    public static partial class CheckLanguageResult
    {
        public interface ICheckLanguageResult { }

        public class TextChecked : ICheckLanguageResult
        {
            public int Certainly { get; }
            public TextChecked(int certainly)
            {
                Certainly = certainly;
            }
        }
        public class TextNotCheck : ICheckLanguageResult
        {
            public string ErrorMessage { get; }
            public TextNotCheck(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }
        public class ManualReviewRequired : ICheckLanguageResult
        {
            public string Text { get; }
            public ManualReviewRequired(string text)
            {
                Text = text;
            }
        }
    }
}

