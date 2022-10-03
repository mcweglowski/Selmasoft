using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QueuePurchaseOrderController : ControllerBase
{
    private ILogger _logger;

    public QueuePurchaseOrderController(ILogger<QueuePurchaseOrderController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult MakePayment([FromBody] PurchaseOrder payment)
    {
        return Ok(payment);
    }
}
