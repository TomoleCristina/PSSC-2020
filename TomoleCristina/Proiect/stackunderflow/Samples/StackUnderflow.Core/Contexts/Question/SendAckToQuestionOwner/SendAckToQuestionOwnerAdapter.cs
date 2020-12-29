using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using GrainInterfaces;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner.SendAckToQuestionOwnerResult;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner
{
    class SendAckToQuestionOwnerAdapter : Adapter<SendAckToQuestionOwnerCmd, ISendAckToQuestionOwnerResult, QuestionWriteContext, QuestionDependencies>
    {
        private readonly IClusterClient clusterClient;

        public SendAckToQuestionOwnerAdapter(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
        public override Task PostConditions(SendAckToQuestionOwnerCmd cmd, ISendAckToQuestionOwnerResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }
        public async override Task<ISendAckToQuestionOwnerResult> Work(SendAckToQuestionOwnerCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>("user1");
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "chat");
            await stream.OnNextAsync("email@address.com");

            return new AckSent(1, 2);
        }
    }
}

