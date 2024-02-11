using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Thread_InterlockClass
    {
        static int counter = 0;

        static void Increase()
        {
            // using Interlocked.anyMethods() will be only of atomic operations like Increment, Decrement and Exchange
            for(int i = 0; i < 1000000; i++)
            {
                Interlocked.Increment(ref counter);
            }
            Console.WriteLine("The counter is: " + counter);
        }
        
        /*static void Main(string[] args)
        {
            Thread t1 = new Thread(Increase);
            Thread t2 = new Thread(Increase);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            // You can also use Task.Run to call the Increase method

            Console.ReadLine();
        }*/
    }
}
