using System.Collections;
using QueueAtTheMarket;

Queue<Customer?> customers = Customer.CustomerFactory(2,2,3,3,4,4);
Counter[] counters = Counter.CounterFactory(2);



Console.WriteLine(GetTotalTime(customers,counters));
int GetTotalTime(Queue<Customer?> customers, Counter[] counters)
{
    int timeTotal = -1;
    int unusedCounters = 0;

    if (customers.Count <= 0)
    {
        return 0;
    }
    if (counters.Length <= 0)
    {
        throw new ArgumentException("There must be at least 1 counter");
    }
    if (counters.Length >= customers.Count)
    {
        return customers.OrderByDescending(c => c!.Time).First()!.Time;
    }

    while (unusedCounters != counters.Length)
    {
        foreach (var counter in counters)
        {
            if (!counter.HasFurtherUsage)
            {
                continue;
            }

            if (counter.CurrentCustomer == null && customers.TryDequeue(out Customer? customer))
            {
                counter.CurrentCustomer = customer;
            }

            if (!counter.Update())
            {
                counter.HasFurtherUsage = false;
                unusedCounters++;
            }
        }
        timeTotal++;
    }
    return timeTotal;
}
