using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QueueCardPaymentController : ControllerBase
{
    private ILogger _logger;

    public QueueCardPaymentController(ILogger<QueueCardPaymentController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult MakePayment([FromBody] CardPayment payment)
    {
        _logger.LogInformation("test");
        return Ok(payment);
    }
}
