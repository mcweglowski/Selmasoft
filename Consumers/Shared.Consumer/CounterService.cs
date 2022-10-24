namespace Shared.Consumer;

public class CounterService
{
    private int Counter = 0;

    public void Increase() => Counter++;

    public override string ToString()
    {
        return Counter.ToString();
    }
}
