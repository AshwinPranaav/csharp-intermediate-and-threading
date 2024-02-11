using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class WhenAnyMethod
    {
        static async Task<int> DoWork(int number, int ms)
        {
            await Task.Delay(ms);
            return number;
        }

        static int DoAnotherWork(int number, int ms)
        {
            Thread.Sleep(ms);
            return number;
        }

        /*static async Task Main(string[] args)
        {
            Task<int> t1 = DoWork(1, 1000);
            Task<int> t2 = DoWork(2, 500);

            Task<int> number = await Task.WhenAny(t1, t2);
            int result = await number;
            Console.WriteLine(result);

            // You can also simulate the same like

            Task<int> t3 = Task.Run(() => DoAnotherWork(3, 1000));
            Task<int> t4 = Task.Run(() => DoAnotherWork(4, 500));

            Task<int> numbers = await Task.WhenAny(t3, t4);
            int result1 = await numbers;
            Console.WriteLine(result1);
        }*/
    }
}
