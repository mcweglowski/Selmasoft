using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Contracts.Responses;

public interface CardPaymentConsumerResponse
{
    public decimal Amount { get; }
    public string CardNumber { get; }
    public string Name { get; }
}
