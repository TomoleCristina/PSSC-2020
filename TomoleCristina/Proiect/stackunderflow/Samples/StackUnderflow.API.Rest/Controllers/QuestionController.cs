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

namespace StackUnderflow.API.AspNetCore.Controllers
{
        [ApiController]
        [Route("question")]
        public class QuestionController : ControllerBase
        {
            private readonly IInterpreterAsync _interpreter;
            private readonly StackUnderflowContext _dbContext;

            public QuestionController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
            {
                _interpreter = interpreter;
                _dbContext = dbContext;
            }

            [HttpPost("CreateQuestion")]
            public async Task<IActionResult> CreateQuestion(CreateQuestionCmd cmd)
            {
                var dep = new QuestionDependencies();
                var ctx = new QuestionWriteContext();

                var expr = from createTenantResult in QuestionContext.CreateQuestion(cmd)
                           select createTenantResult;

                var r = await _interpreter.Interpret(expr, ctx, dep);

                return r.Match(
                    created => Ok(created),
                    notCreated => BadRequest(notCreated),
                    invalidRequest => ValidationProblem()
                    );
            }
        }
    }