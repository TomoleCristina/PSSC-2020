using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostNewQuestionWorkflow
{
    [Serializable]
    public class InvalidTagsException : Exception
    {
        public InvalidTagsException()
        { }
        public InvalidTagsException(List<string> tags) : base($"Question must have at least 1 tag, and at most 3 tags")
        {

        }
    }
}
