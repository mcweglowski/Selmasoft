namespace Payments.Contracts;

public interface CardPaymentRequest
{
    public Guid Id { get; set; }
    public decimal Amount { get; }
    public string BankAccount { get; }
    public string Name { get; }
}

public interface CardPaymentConsumerResponse
{
    public Guid Id { get; set; }
    public decimal Amount { get; }
    public string BankAccount { get; }
    public string Name { get; }
}
