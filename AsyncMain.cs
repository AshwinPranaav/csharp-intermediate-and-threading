using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AsyncMain
    {
        static async Task<int> Main(string[] args)
        {
            await Task.Delay(1000);
            Console.ReadLine();
            return 0;
        }
    }
}
