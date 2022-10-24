namespace Payments.API.Requests
{
    public class CashPayment
    {
        public Guid Id { get; set; } = Guid.Empty;
        public decimal Amount { get; init; } = 0;
        public string BankAccount { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
    }
}
