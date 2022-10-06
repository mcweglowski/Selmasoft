using MassTransit;
using Microsoft.Extensions.Logging;
using Payments.Contracts;
using RequestCardPayment.Consumer.Support;

namespace RequestCardPayment.Consumer.Consumers;

public class CardPaymentRequestConsumer : IConsumer<CardPaymentRequest>
{
    private ILogger _logger;
    private CounterService _counter;

    public CardPaymentRequestConsumer(ILogger<CardPaymentRequestConsumer> logger, CounterService counter)
    {
        _logger = logger;
        _counter = counter;
    }

    public async Task Consume(ConsumeContext<CardPaymentRequest> context)
    {
        _counter.Increase();
        _logger.LogInformation($"CardPaymentRequestConsumer: {context.Message.Id}, {context.Message.Name}, {context.Message.BankAccount}, {context.Message.Amount}");
        _logger.LogInformation($"Processed: {_counter}");

        await context.RespondAsync<CardPaymentConsumerResponse>(new 
        {
            Id = context.Message.Id,
            Amount = context.Message.Amount,
            CardNumber = context.Message.BankAccount,
            Name = context.Message.Name
        });
    }
}
