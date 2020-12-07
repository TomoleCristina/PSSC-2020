using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflow.DatabaseModel.Models;
using StackUnderflow.EF;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public class QuestionWriteContext
    {
        public ICollection<Questions> Questions { get; }
        public QuestionWriteContext(ICollection<Questions> questions)
        {
            Questions = questions ?? new List<Questions>();
        }
    }
}
