namespace Payments.API.Requests;

public record PaymentRequest
{
    public string Name { get; init; }
    public decimal Amount { get; set; }
}
