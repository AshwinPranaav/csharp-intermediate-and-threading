using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class C_Lock
    {
        static int counterNoLock = 0;
        static int counterLock = 0;

        static object lockObj = new object();

        static void WithoutLock()
        {
            for (int i = 0; i < 1000000; i++)
            {
                counterNoLock++;
            }
            Console.WriteLine($"Counter No Lock: {counterNoLock}");
        }

        static void WithLock()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (lockObj)
                {
                    counterLock++;
                }
            }
            Console.WriteLine($"Counter With Lock: {counterLock}");
        }

        /*static void Main(string[] args)
        {
            Task.Run(() => WithoutLock());
            Task.Run(() => WithoutLock());
            Task.Run(() => WithLock());
            Task.Run(() => WithLock());

            Console.ReadLine();
        }*/
    }
}
