using MassTransit;
using Microsoft.Extensions.Logging;
using Payments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        await Task.CompletedTask;
    }
}
