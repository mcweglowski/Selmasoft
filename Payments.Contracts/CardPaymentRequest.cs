﻿namespace Payments.Contracts;

public interface CardPaymentRequest
{
    public decimal Amount { get; }
    public string CardNumber { get; }
    public string Name { get; }
}

public interface CardPaymentConsumerResponse
{
    public decimal Amount { get; }
    public string CardNumber { get; }
    public string Name { get; }
}
