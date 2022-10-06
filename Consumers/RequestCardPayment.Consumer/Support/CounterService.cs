using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestCardPayment.Consumer.Support;

public class CounterService
{
    private int Counter = 0;

    public void Increase() => Counter++;

    public override string ToString()
    {
        return Counter.ToString();
    }
}
