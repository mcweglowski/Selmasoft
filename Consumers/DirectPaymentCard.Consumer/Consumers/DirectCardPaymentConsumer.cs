using MassTransit;
using Microsoft.Extensions.Logging;
using Payments.Contracts;

namespace DirectPaymentCard.Consumer.Consumers
{
    public class DirectCardPaymentConsumer : IConsumer<DirectCardPaymentRequest>
    {
        ILogger _logger;

        public DirectCardPaymentConsumer(ILogger<DirectCardPaymentConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<DirectCardPaymentRequest> context)
        {
            _logger.LogInformation($"{context.Message.Name} {context.Message.Amount}");

            await context.RespondAsync<DirectCardPaymentResponse>(new
            {
                Name = context.Message.Name,
                Amount = context.Message.Amount
            });
        }
    }
}
