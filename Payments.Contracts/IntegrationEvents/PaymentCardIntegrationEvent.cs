using System.Runtime.Serialization;

namespace Payments.Contracts.IntegrationEvents;

public record PaymentCardIntegrationEvent : BaseIntegrationEvent
{
    public PaymentCardIntegrationEvent()
    {
        EventType = "selmasoft.payment.card";
    }

    //public override string EventType => "selmasoft.payment.card";
}
