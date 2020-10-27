using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using System.Linq;

namespace Question.Domain.PostNewQuestionWorkflow
{
    [AsChoice]
    public static partial class PostNewQuestionResult
    {
        public interface IPostNewQuestionResult { }                //interfata marker
        public class QuestionPosted : IPostNewQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Body { get; private set; }
            public string Tags { get; private set; }
            public int CountVotes { get; private set; }
            public IReadOnlyCollection<VoteEnum> Votes { get; private set; }
            public QuestionPosted(Guid questionId, string title, string body, string tags, int countVotes, IReadOnlyCollection<VoteEnum> votes)              
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;
                CountVotes = countVotes;
                Votes = votes;

            }
        }
        public class QuestionNotPosted : IPostNewQuestionResult                                       
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        public class QuestionValidationFailed : IPostNewQuestionResult          //daca intrebarea e  inadecvata
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
