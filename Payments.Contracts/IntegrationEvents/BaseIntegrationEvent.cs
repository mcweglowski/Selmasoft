using System.Runtime.Serialization;

namespace Payments.Contracts.IntegrationEvents;

public abstract record BaseIntegrationEvent
{
    public Guid Id { get; }
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public abstract string EventType { get; }
}