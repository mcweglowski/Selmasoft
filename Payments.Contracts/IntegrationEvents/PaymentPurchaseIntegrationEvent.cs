using System.Runtime.Serialization;

namespace Payments.Contracts.IntegrationEvents;

public record PaymentPurchaseIntegrationEvent : BaseIntegrationEvent
{
    public override string EventType => "selmasoft.payment.purchase";
}
