using System.Runtime.Serialization;

namespace Payments.Contracts.IntegrationEvents;

public record PaymentCardIntegrationEvent : BaseIntegrationEvent
{
    public override string EventType => "selmasoft.payment.card";
}
