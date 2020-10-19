using Question.Domain.PostNewQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using static Question.Domain.PostNewQuestionWorkflow.PostNewQuestionResult;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var cmd = new PostNewQuestionCmd("Opening Simulink Models created in newer versions of Matlab", "How can i open a Simulink model created in newer version of Matlab? I mention that the model is created in Matlab 2019a and i have Matlab 2015a.", "Simulink, Matlab, Version");
            var result = PostNewQuestion(cmd);
            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }
        private static IPostNewQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }
        private static IPostNewQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotCreatedResult)
        {
            Console.WriteLine($"Question not posted: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }
        private static IPostNewQuestionResult ProcessQuestionPosted(QuestionPosted question)
        {
            var user = new UserLogin("user1", "user@gmail.com");
            Console.WriteLine($"Question {question.QuestionId}");
            Console.WriteLine($"Confirmation about posting question {user.EmailAdress}");
            return question;
        }
        public static IPostNewQuestionResult PostNewQuestion(PostNewQuestionCmd postNewQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(postNewQuestionCommand.Title))
            {
                return new QuestionNotPosted("Please insert a title!");
            }
            if (string.IsNullOrWhiteSpace(postNewQuestionCommand.Body))
            {
                var errors = new List<string>() { "Invalid description of question!" };
                return new QuestionValidationFailed(errors);
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, postNewQuestionCommand.Title, postNewQuestionCommand.Tags, postNewQuestionCommand.Body);

            return result;
        }
    }
}

