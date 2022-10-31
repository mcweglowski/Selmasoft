using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;
using Payments.Contracts.IntegrationEvents;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QueueCardPaymentController : ControllerBase
{
    private ILogger _logger;
    private IBus _bus;

    public QueueCardPaymentController(ILogger<QueueCardPaymentController> logger,
        IBus bus)
    {
        _logger = logger;
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] CardPayment payment)
    {
        _logger.LogInformation($"{payment.Name} {payment.Amount}");

        await _bus.Publish((BaseIntegrationEvent)new PaymentCardIntegrationEvent()
        {
            Name = payment.Name,
            Amount = payment.Amount
        });;
        
        return Ok(payment);
    }
}
