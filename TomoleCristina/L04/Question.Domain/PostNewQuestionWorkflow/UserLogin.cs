using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostNewQuestionWorkflow
{
    /// <summary>
    /// SUM type ProfileId * EmailAdress
    /// </summary>
    public struct UserLogin
    {
        [Required]
        public string ProfileId { get; private set; }
        [Required]
        public string EmailAdress { get; private set; }

        public UserLogin(string profileId, string emailAdress)
        {
            ProfileId = profileId;
            EmailAdress = emailAdress;
        }
    }
}
