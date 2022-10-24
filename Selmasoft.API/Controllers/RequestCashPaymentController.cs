using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Requests;
using Payments.Contracts;

namespace Payments.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RequestCashPaymentController : ControllerBase
{
    private ILogger _logger;
    private IRequestClient<CashPaymentRequest> _cashPaymentRequestClient;

    public RequestCashPaymentController(ILogger<RequestCashPaymentController> logger,
        IRequestClient<CashPaymentRequest> cashPaymentRequestClient)
    {
        _logger = logger;
        _cashPaymentRequestClient = cashPaymentRequestClient;
    }

    [HttpPost]
    public async Task<IActionResult> MakePayment([FromBody] CashPayment payment)
    {
        _logger.LogInformation($"MakeCashPayment, {payment.Id}, {payment.Name}, {payment.BankAccount}, {payment.Amount}");

        var response = await _cashPaymentRequestClient.GetResponse<CashPaymentResponse>(new
        {
            Id = payment.Id,
            Amount = payment.Amount,
            BankAccount = payment.BankAccount,
            Name = payment.Name
        });

        return Ok(response);
    }
}
