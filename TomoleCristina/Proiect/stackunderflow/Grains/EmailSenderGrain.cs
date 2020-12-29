using System;
using System.Collections.Generic;
using System.Text;
using GrainInterfaces;
using System.Threading.Tasks;

namespace Grains
{
    public class EmailSenderGrain : Orleans.Grain, IEmailSender
    {
        public Task<string> SendEmailAsync(string message)
        {

            // send e-mail

            return Task.FromResult(message);
        }
    }
}
