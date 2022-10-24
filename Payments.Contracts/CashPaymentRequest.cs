namespace Payments.Contracts;

public interface CashPaymentRequest
{
    public Guid Id { get; set; }
    public decimal Amount { get; }
    public string BankAccount { get; }
    public string Name { get; }
}

public interface CashPaymentResponse
{
    public Guid Id { get; set; }
    public decimal Amount { get; }
    public string BankAccount { get; }
    public string Name { get; }
}
