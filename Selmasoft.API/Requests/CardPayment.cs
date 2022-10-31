namespace Payments.API.Requests;

public class CardPayment
{
    public decimal Amount { get; init; } = 0;
    public string Name { get; init; } = string.Empty;
}
