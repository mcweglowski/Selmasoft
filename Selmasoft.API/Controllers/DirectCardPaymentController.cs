using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;
using Payments.Contracts;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectCardPaymentController : ControllerBase
{
    ILogger _logger;
    IRequestClient<DirectCardPaymentRequest> _requestClient;

    public DirectCardPaymentController(ILogger<DirectCardPaymentController> logger, IRequestClient<DirectCardPaymentRequest> requestClient)
    {
        _logger = logger;
        _requestClient = requestClient;
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] PaymentRequest request)
    {
        _logger.LogInformation($"{request.Name} {request.Amount}");

        var response = await _requestClient.GetResponse<DirectCardPaymentResponse>(new
        {
            Name = request.Name,
            Amount = request.Amount
        });

        return Ok(response);
    }
}
