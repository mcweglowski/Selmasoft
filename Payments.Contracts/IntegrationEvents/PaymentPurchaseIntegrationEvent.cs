using System.Runtime.Serialization;

namespace Payments.Contracts.IntegrationEvents;

public record PaymentPurchaseIntegrationEvent : BaseIntegrationEvent
{
    public PaymentPurchaseIntegrationEvent()
    {
        EventType = "selmasoft.payment.purchase";
    }

    //public override string EventType => "selmasoft.payment.purchase";
}
