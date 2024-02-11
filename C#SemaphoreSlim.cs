using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class C_SemaphoreSlim
    {
        static int amount = 0;

        static SemaphoreSlim semaphore = new(3);

        static async Task AccessAmountAsync(int id)
        {
            Console.WriteLine($"Task {id} is waiting to access the amount");
            await semaphore.WaitAsync();

            try
            {
                Console.WriteLine($"Task {id} is accessing the amount");

                await Task.Delay(1000); // simulate a delay in accessing the amount

                Interlocked.Increment(ref amount);

                Console.WriteLine($"Task {id} has completed accessing the amount {amount}");
            }
            finally
            {
                semaphore.Release();
            }
        }

        /*static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            for(int i = 0; i< 10; i++)
            {
                tasks.Add(AccessAmountAsync(i));
            }

            Task.WhenAll(tasks).Wait();
        }*/
    }
}
