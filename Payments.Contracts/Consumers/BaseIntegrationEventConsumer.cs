using MassTransit;
using Microsoft.Extensions.Logging;
using Payments.Contracts.IntegrationEvents;

namespace Payments.Contracts.Consumers;

public class BaseIntegrationEventConsumer : IConsumer<BaseIntegrationEvent>
{
    private ILogger _logger;

    public BaseIntegrationEventConsumer(ILogger<BaseIntegrationEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<BaseIntegrationEvent> context)
    {
        _logger.LogInformation($"{context.Message.Name} {context.Message.Amount}");
    }
}
