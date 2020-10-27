using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt.Common;
using static Question.Domain.PostNewQuestionWorkflow.PostNewQuestionResult;

namespace Question.Domain.PostNewQuestionWorkflow
{
    [AsChoice]
    public static partial class VerifyVotes
    {
        public interface IVotes { }
        public class UnverifiedNumberOfVotes : IVotes
        {
            public int Votes { get; private set; }
            private UnverifiedNumberOfVotes(int votes)
            {
                Votes = votes;
            }

            public static Result<UnverifiedNumberOfVotes> Create(int votes)
            {
                if (ValidNumberOfVotes(votes))
                {
                    return new UnverifiedNumberOfVotes(votes);
                }
                else
                {
                    return new Result<UnverifiedNumberOfVotes>(new InvalidVotesException(votes));
                }
            }
            private static bool ValidNumberOfVotes(int votes)
            {
                if(votes != 0)
                { 
                    return true;
                }
                return false;
            }
        }
        public class VerifiedNumberOfVotes : IVotes
        {
            public int Votes { get; private set; }
            internal VerifiedNumberOfVotes(int votes)
            {
                Votes = votes;
            }
        }
    }
}
