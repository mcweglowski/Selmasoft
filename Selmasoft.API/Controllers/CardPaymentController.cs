using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;
using Payments.Contracts.IntegrationEvents;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CardPaymentController : ControllerBase
{
    private ILogger _logger;
    private IBus _bus;

    public CardPaymentController(ILogger<CardPaymentController> logger,
        IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] CardPayment payment)
    {
        _logger.LogInformation($"{payment.Name} {payment.Amount}");

        var @event = (BaseIntegrationEvent) new PaymentCardIntegrationEvent()
        {
            Name = payment.Name,
            Amount = payment.Amount
        };

        await _bus.Publish(@event);
        
        return Ok(payment);
    }
}
