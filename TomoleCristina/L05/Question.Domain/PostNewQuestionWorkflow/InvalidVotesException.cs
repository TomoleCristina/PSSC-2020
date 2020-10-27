using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostNewQuestionWorkflow
{
    [Serializable]
    public class InvalidVotesException : Exception
    {
        public InvalidVotesException()
        { }
        public InvalidVotesException(int votes) : base($"The value \"{votes}\"  doesn't correspond to sum of individual votes")
        {

        }
    }
}
