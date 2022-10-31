using System.Runtime.Serialization;

namespace Payments.Contracts.IntegrationEvents;

public record BaseIntegrationEvent
{
    public Guid Id { get; }
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public string EventType { get; set; }
}