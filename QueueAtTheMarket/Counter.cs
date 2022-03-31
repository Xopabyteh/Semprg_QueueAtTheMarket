namespace QueueAtTheMarket;

public class Counter
{
    public Customer? CurrentCustomer { get; set; }
    public bool HasFurtherUsage { get; set; } = true;
    public bool Update()
    {
        if (CurrentCustomer != null)
        {
            CurrentCustomer.Time--;
            if (CurrentCustomer.Time <= 0)
            {
                CurrentCustomer = null;
            }

            return true;
        }
        return false;
    }

    public static Counter[] CounterFactory(int amm)
    {
        Counter[] counters = new Counter[amm];
        for (int i = 0; i < amm; i++)
        {
            counters[i] = new Counter();
        }

        return counters;
    }
}