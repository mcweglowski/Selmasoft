namespace Payments.Contracts;

public interface DirectCardPaymentRequest
{
    public string Name { get; }
    public decimal Amount { get; }
}

public interface DirectCardPaymentResponse
{
    public string Name { get; }
    public decimal Amount { get; }
}
