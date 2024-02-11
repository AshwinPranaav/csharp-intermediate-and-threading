using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TaskClass
    {
        static int GetSqaure(int n)
        {
            Thread.Sleep(3000);
            return n * n;
        }

        /*static void Main(string[] args)
        {
            int result = 0;
            Task<int> task = Task.Run(() => GetSqaure(6));
            
            // this will block the main thread, so the while loop won't be reached until then, so use continueWith
            //result = task.Result;
            
            Task task2 = task.ContinueWith(task => { 
                Math.Pow(task.Result, 2);
            });

            Task task3 = task2.ContinueWith(task => {
                Math.Pow(task2.Result, 2);
            });

            while (result == 0)
            {
                Console.WriteLine("Waiting for result");
                Thread.Sleep(1000);
            }

            //Console.WriteLine(result);
        }*/
    }
}
