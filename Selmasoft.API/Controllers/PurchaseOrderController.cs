using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseOrderController : ControllerBase
{
    private ILogger _logger;

    public PurchaseOrderController(ILogger<PurchaseOrderController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public ActionResult MakePayment([FromBody] PurchaseOrder payment)
    {
        return Ok(payment);
    }
}
