using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;
using Payments.Contracts;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestCardPaymentController : ControllerBase
{
    private ILogger _logger;
    private IRequestClient<CardPaymentRequest> _cardPaymentRequestClient;

    public RequestCardPaymentController(ILogger<RequestCardPaymentController> logger,
        IRequestClient<CardPaymentRequest> cardPaymentRequestClient)
    {
        _logger = logger;
        _cardPaymentRequestClient = cardPaymentRequestClient;
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] CardPayment payment)
    {
        _logger.LogInformation("MakePayment");

        var response = await _cardPaymentRequestClient.GetResponse<CardPaymentConsumerResponse>(new
        {
            Amount = 20,
            CardNumber = "1234",
            Name = "Marcin",
        });

        return Ok(response);
    }
}
