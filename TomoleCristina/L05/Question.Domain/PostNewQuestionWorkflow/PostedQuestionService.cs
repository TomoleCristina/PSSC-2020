using System;
using System.Collections.Generic;
using System.Text;
using static Question.Domain.PostNewQuestionWorkflow.VerifyQuestionDescription;
using LanguageExt.Common;

namespace Question.Domain.PostNewQuestionWorkflow
{
   public class PostedQuestionService
    {
        public Result<VerifiedQuestionDescription> PostQuestion(UnverifiedQuestionDescription question)
        {
            //publica intrebarea daca respecta conditiile(intrebarea sa nu aibe mai mult de 1000 caractere,
            //si sa aibe cel putin 1 tag si cel mult 3 tag-uri

            return new VerifiedQuestionDescription(question.Question, question.Tags);
        }
    }
}
