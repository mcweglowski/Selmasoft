using MassTransit;
using Microsoft.Extensions.Logging;
using Payments.Contracts;

namespace RequestCardPayment.Consumer.Consumers;

public class CardPaymentRequestConsumer : IConsumer<CardPaymentRequest>
{
    private ILogger _logger;

    public CardPaymentRequestConsumer(ILogger<CardPaymentRequestConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CardPaymentRequest> context)
    {
        _logger.LogInformation($"CardPaymentRequestConsumer: {context.Message.Amount}, {context.Message.CardNumber}, {context.Message.Amount}");

        await context.RespondAsync<CardPaymentConsumerResponse>(new 
        {
            Amount = 20,
            CardNumber = "1234",
            Name = "Marcin"
        });
    }
}
