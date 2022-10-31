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
    public async Task<IActionResult> MakePayment([FromBody] CardPaymentRequest payment)
    {
        _logger.LogInformation($"MakeCardPayment: {payment.Id}, {payment.Name}, {payment.BankAccount}, {payment.Amount}");

        var response = await _cardPaymentRequestClient.GetResponse<CardPaymentConsumerResponse>(new
        {
            Id = payment.Id,
            Amount = payment.Amount,
            BankAccount = payment.BankAccount,
            Name = payment.Name,
        });

        return Ok(response);
    }
}
