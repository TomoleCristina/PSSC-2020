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
namespace StackUnderflow.API.AspNetCore.Controllers
{
        [ApiController]
        [Route("question")]
        public class QuestionController : ControllerBase
        {
            private readonly IInterpreterAsync _interpreter;
            private readonly DatabaseContext _dbContext;

            public QuestionController(IInterpreterAsync interpreter, DatabaseContext dbContext)
            {
                _interpreter = interpreter;
                _dbContext = dbContext;
            }

            [HttpPost("CreateQuestion")]
            public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCmd cmd)
            {
                var dep = new QuestionDependencies();
                var questions = await _dbContext.Questions.ToListAsync();
             //_dbContext.Questions.AttachRange(questions);
             var ctx = new QuestionWriteContext(new EFList<Questions>(_dbContext.Questions));
           // var ctx = new QuestionWriteContext(questions);

            var expr = from createQuestionResult in QuestionContext.CreateQuestion(cmd)
                       select createQuestionResult;

            /* var expr = from createQuestionResult in QuestionContext.CreateQuestion(cmd)
                        from checkLanguageResult in QuestionContext.CheckLanguage(new CheckLanguageCmd(cmd.Body))
                        from sendAckToQuestionOwnerCmd in QuestionContext.SendAckToQuestionOwner(new SendAckToQuestionOwnerCmd(1, 2))
                        select createQuestionResult */

            var r = await _interpreter.Interpret(expr, ctx, dep);

            await _dbContext.Questions.Add(new DatabaseModel.Models.Questions { Title = cmd.Title, Body = cmd.Body, Tags = cmd.Tags }).GetDatabaseValuesAsync();
            //var question=await _dbContext.Questions.Where(r => r.QuestionId== new Guid("20000000-0000-0000-0000-000000000000")).SingleOrDefaultAsync();
           
           // _dbContext.Questions.Update(question);
            await _dbContext.SaveChangesAsync();

            return r.Match(
                    created => (IActionResult)Ok(created.Body),
                    notcreated => BadRequest("NotPosted"),
                    invalidRequest => ValidationProblem()
                    );
            }
        }
    }