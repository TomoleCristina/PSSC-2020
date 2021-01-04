using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using StackUnderflow.Domain.Core.Contexts.Question;
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.Domain.Core.Contexts.Question.CheckLanguage;
using StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion.CreateQuestionResult;
using Orleans;
using GrainInterfaces;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("question-projection")]
    public class QuestionProjectionController : ControllerBase
    {
        private readonly IClusterClient clusterClient;

        public QuestionProjectionController(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllQuestions()
        {
            //var questions = GetQuestionsFromDB();
            var questionsProjectionGrain = this.clusterClient.GetGrain<IQuestionProjectionGrain>("organisation1");
            var questions = await questionsProjectionGrain.GetQuestionsAsync();

            return Ok(questions);
        }

        private List<Post> GetQuestionsFromDB()
        {
            return new List<Post> {
            new Post
            {
                PostId = 1,
                PostText = "My question text"
            }
            };
        }
    }
}
