using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostNewQuestionWorkflow
{
    /// <summary>
    /// SUM type Title * Body * Tags
    /// </summary>
    public struct PostNewQuestionCmd
    {
        [Required]
        public string Title { get; private set; }           //titlul intrebarii
        [Required]
        public string Body { get; private set; }            //descrierea detaliala a intrebarii
        public string Tags { get; set; }                     //domeniul/domeniile din care face parte intrebarea
        public PostNewQuestionCmd(string title, string body, string tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
}
