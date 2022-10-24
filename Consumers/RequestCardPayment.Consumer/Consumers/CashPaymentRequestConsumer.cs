using MassTransit;
using Microsoft.Extensions.Logging;
using Payments.Contracts;
using Shared.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestCardPayment.Consumer.Consumers;

public class CashPaymentRequestConsumer : IConsumer<CashPaymentRequest>
{
    private ILogger _logger;
    private CounterService _counter;

    public CashPaymentRequestConsumer(ILogger<CashPaymentRequestConsumer> logger, CounterService counter)
    {
        _logger = logger;
        _counter = counter;
    }

    public async Task Consume(ConsumeContext<CashPaymentRequest> context)
    {
        _counter.Increase();
        _logger.LogInformation($"CashPaymentRequestConsumer: {context.Message.Id}, {context.Message.Name}, {context.Message.BankAccount}, {context.Message.Amount}");
        _logger.LogInformation($"Processed: {_counter}");

        await context.RespondAsync<CashPaymentResponse>(new
        {
            Id = context.Message.Id,
            Amount = context.Message.Amount,
            BankAccount = context.Message.BankAccount,
            Name = context.Message.Name
        });
    }
}
