using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Question.Domain.PostNewQuestionWorkflow
{
    /// <summary>
    /// SUM type Title * Body * Tags * Votes
    /// </summary>
    public struct PostNewQuestionCmd
    {
        [Required]
        public string Title { get; private set; }           //titlul intrebarii
        [Required]
        [MaxLength(1000)]
        public string Body { get; private set; }            //descrierea detaliala a intrebarii
       [Required]
        public List<string> Tags { get; set; }                     //domeniul/domeniile din care face parte intrebarea
       public int Votes { get; private set; }
        public PostNewQuestionCmd(string title, string body, List<string> tags, int votes)
        {
            Title = title;
            Body = body;
            Tags = tags;
            Votes = votes;
        }
    }
}
