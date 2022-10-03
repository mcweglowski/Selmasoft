using Microsoft.AspNetCore.Mvc;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectCardPaymentController : ControllerBase
{
    ILogger _logger;

    public DirectCardPaymentController(ILogger<DirectCardPaymentController> logger)
    {
        _logger = logger;
    }
}
