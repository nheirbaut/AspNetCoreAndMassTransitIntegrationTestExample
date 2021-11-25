using System;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

namespace AspNetCoreAndMassTransitIntegrationTestExample.Api.Consumers
{
    public class MessageConsumer
        : IConsumer<Message>,
          IConsumer<Fault<Message>>
    {
        private readonly ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            _logger.LogInformation($"Consumed message: '{context.Message.Text}'");

            if (context.Message.ThrowException)
            {
                throw new InvalidOperationException("Something went wrong");
            }

            return Task.CompletedTask;
        }

        public Task Consume(ConsumeContext<Fault<Message>> context)
        {
            _logger.LogError($"Consumed fault: {context.Message.Exceptions.First().Message}");
            return Task.CompletedTask;
        }
    }

    public interface Message
    {
        string Text { get; set; }
        public bool ThrowException { get; set; }
    }
}