using System.Collections;

namespace QueueAtTheMarket;

public class Customer
{
    public int Time { get; set; }

    public Customer(int time)
    {
        Time = time;
    }

    public static Queue<Customer?> CustomerFactory(params int[] times)
    {
        Queue<Customer?> customers = new Queue<Customer?>();
        foreach (var time in times)
        {
            customers.Enqueue(new Customer(time));
        }
        return customers;
    }
}