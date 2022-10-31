using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;
using Payments.Contracts.IntegrationEvents;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseOrderController : ControllerBase
{
    private ILogger _logger;
    private IBus _bus;

    public PurchaseOrderController(ILogger<PurchaseOrderController> logger,
        IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] PurchaseOrder payment)
    {
        _logger.LogInformation($"{payment.Name} {payment.Amount}");

        var @event = (BaseIntegrationEvent)new PaymentPurchaseIntegrationEvent()
        {
            Name = payment.Name,
            Amount = payment.Amount
        };

        await _bus.Publish(@event);

        return Ok(payment);
    }
}
